using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
namespace Features
{
    public enum Feature { BIT_EXACT = 0, BAD_CONTRAST, SIMILARITY, PARTIAL_BLOCKAGE, NUM_FEATURES };


  

    public class FeaturesLayer : IDisposable
    {              

        private bool _disposed;
        
        private ImageInfo[] _images;
        
        private BitExact _bitExact;
        private Thread _bitExactThread;

        private BadContrast _badContrast;
        private Thread _badContrastThread;

        private Thread _loadingImagesThread;

        private int _numRunningFeat;


        # region (GUI <-> BRAIN) shared data

        private int _loadingImagesStatus; // read only
        private int _runStatus; // read only
        private Task _task;
        private Results _res;    

        #endregion

        public FeaturesLayer(ref Task task)
        {
            _disposed = false;
            // copy task
            _task = new Task(task);
            // init results struct
            _res = new Results();

            _numRunningFeat = 0;
            // features vars
            _bitExactThread = null;
            _bitExact = null;
            _badContrast = null;
            _badContrastThread = null;
            // ---------------
            // set status to 0
            _loadingImagesStatus = 0;
            _runStatus = 0;
            // allocate memory for ImageInfo array
            _images = new ImageInfo[task.ImagePathes.Count];
            for(int i=0; i<_images.Length; i++)
                _images[i] = null;
            // this will run loading images from run()
            _loadingImagesThread = null;
        }        

        # region (GUI --> BRAIN) Methods

        /// <summary>
        /// This Property holds the features results structs
        /// </summary>
        public Results Res
        {
            get { return _res; }
        }
        /// <summary>
        /// returns the completion percetage of the loadImages() method
        /// </summary>
        /// 
        public int LoadingImagesStatus
        {
            get { return _loadingImagesStatus; }
        }
        /// <summary>
        /// sets the array of ImageInfo and creates the objects
        /// Throws any generated Exception on ImageInfo constructor call
        /// </summary>
        public void loadImages()
        {
            if (_loadingImagesThread != null) { return; }

            _loadingImagesThread = new Thread(startLoadingImages);
            _loadingImagesThread.Start();
        }
        private void startLoadingImages()
        {
            for (int i = 0; i < _images.Length; i++)
            {
                try
                {
                    _images[i] = new ImageInfo(_task.ImagePathes[i]);
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                    return;
                }
                catch (Exception e)
                {
                    throw e;
                }
                _loadingImagesStatus = (int)(((float)(i + 1) * 100) / _images.Length);
            }
        }
        /// <summary>
        /// Get the RunStatus of the running features
        /// </summary>
        public int RunStatus
        {
            get { return updateRunStatus(); }
        }
        /// <summary>
        /// This will be called in a different thread, 
        /// It will start the features run and the statusUpdater
        /// </summary>
        public void run()
        {
        
            if (_task.Features[(int)Feature.BIT_EXACT])
            {            
                _bitExact = new BitExact(_images);
                _bitExactThread = new Thread(_bitExact.run);
                _bitExactThread.Name = "bitExact";
                _bitExactThread.Start();
                _numRunningFeat++;
            }
            if (_task.Features[(int)Feature.BAD_CONTRAST])
            {
                _badContrast = new BadContrast(_images);
                _badContrastThread = new Thread(_badContrast.run);
                _badContrastThread.Start();
                _numRunningFeat++;
            }

            //_statusUpdaterThread = new Thread(statusUpdater);
            //_statusUpdaterThread.Start();

        }
        #endregion (GUI --> BRAIN) Methods

        /// <summary>
        /// will update RunStatus and on completion, will collect results
        /// </summary>
        /// <returns></returns>
        private int updateRunStatus()
        {
            _runStatus = 0;
            if (_bitExact != null)
            {
                _runStatus += _bitExact.RunStatus/_numRunningFeat;
                if (_bitExact.RunStatus == 100)
                {
                    _res.setBitExact(_bitExact.Results);
                    _bitExact = null;
                    _bitExactThread = null;
                }                
            }
            if (_badContrast != null)
            {
                _runStatus += _badContrast.RunStatus / _numRunningFeat;
                if (_badContrast.RunStatus == 100)
                {
                    _res.setBadContrast(_badContrast.Results);
                    _badContrast = null;
                    _badContrastThread = null;
                }                
            }
            return _runStatus;
        }



        #region ***************IDisposable*******************

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {            
            if (!_disposed) {            
                // clear bitExact
                bool isLoadingImages = (_loadingImagesThread != null && _loadingImagesThread.IsAlive);

                if (isLoadingImages)
                {
                    _loadingImagesThread.Abort();
                }
                else
                {
                    bool isBitExactRunning = (_bitExact != null && _bitExactThread != null &&
                                              _bitExactThread.IsAlive);
                    if (isBitExactRunning)
                    {
                        _bitExactThread.Abort();
                    }
                    _bitExact = null;
                    _bitExactThread = null;
                }
                // clear images
                // assuming that if im[i] is null im[i +..] is null
                for (int i=0; i< _images.Length; i++) {
                    if (_images[i] != null) {
                        _images[i].Dispose();
                        _images[i] = null;
                    }
                    else {
                        break;
                    }
                }
                _disposed = true;
            }
        }
        ~FeaturesLayer()
        {
            Dispose(false);
        }

        #endregion ***************IDisposable*******************


    }


}
