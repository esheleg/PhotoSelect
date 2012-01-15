using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
namespace Features
{
    public enum Feature { BIT_EXACT = 0, BAD_CONTRAST, SIMILARITY, PARTIAL_BLOCKAGE, NUM_FEATURES };


    # region ******************(GUI <--> BRAIN) Structures********************
    /// <summary>
    /// // this struct will recieve the task information from the gui
    /// </summary>
    /// 
    public struct Task
    {// TODO - test and check if refernced objects can realy be readonly
        private List<string> _pathes;
        public List<string> ImagePathes
        {
            get { return _pathes; }
        }                
        private bool[] _features;
        public bool[] Features
        {
            get { return _features; }
        }
        /// <summary>
        /// DeepCopy constructor
        /// </summary>
        /// <param name="from"></param>
        public Task(Task from) : this(from.ImagePathes, from.Features) {}

        public Task(List<string> pathes, bool[] feauters)
        {

            // copy pathes
            _pathes = new List<string>(pathes.Count);
            foreach (string path in pathes)
                _pathes.Add(path);
            // copy features flags
            _features = new bool[feauters.Length];
            feauters.CopyTo(_features,0);
        }        

    }
    /// <summary>
    /// // this is the struct that will be returned after the BitExact Feature process is ended
    /// </summary>
    public struct BitExactRes
    {
        private List<List<string>> _matches;
        /// <summary>
        /// deep copy of matches
        /// </summary>
        public BitExactRes(List<List<string>> matches)
        {// TODO - need to change this to array
            _matches = new List<List<string>>(matches.Count);
            foreach (List<string> lst in matches)
            {
                _matches.Add(new List<string>(lst.Count));
                foreach (string path in lst)
                {
                    _matches.Last().Add(path);
                }
            }
        }
        public List<List<string>> Matches
        {            
            get { return _matches; }            
        }
    }

    // BadContrustRes added by Yossi
    public struct BadContrastRes
    {
        private List<string> _matches;
        /// <summary>
        /// deep copy of matches
        /// </summary>

        public BadContrastRes(List<string> matches)
        {// TODO - need to change this to array
            _matches = new List<string>(matches.Count);
            foreach (string path in matches)
            {
                _matches.Add(path);
            }


        }

        public List<string> Matches
        {
            get { return _matches; }
        }
    }

    public struct Results
    {
        private BitExactRes _bitExactRes;
        public Results(BitExactRes bitExactRes)
        {
            _bitExactRes = new BitExactRes(bitExactRes.Matches);
        }
        public BitExactRes BitExact
        {
            get { return _bitExactRes; }
        }
        public void setBitExact(BitExactRes bitExactRes)
        {
            _bitExactRes = new BitExactRes(bitExactRes.Matches);
        }

    }
    #endregion ******************(GUI <--> BRAIN) Structures********************

    public class FeaturesLayer : IDisposable
    {              

        private bool _disposed;
        
        private ImageInfo[] _images;
        
        private BitExact _bitExact;
        private Thread _bitExactThread;

        private Thread _loadingImagesThread;



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
            _bitExactThread = null;
            _bitExact = null;
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
            if (_bitExact != null)
            {
                _runStatus = _bitExact.RunStatus;
                if (_runStatus == 100)
                {
                    _res.setBitExact(_bitExact.Results);
                    _bitExact = null;
                    _bitExactThread = null;
                }                
            }
            return _runStatus;
        }

        /// <summary>
        /// This will update (in diff thread)  _runStatus;
        /// </summary>
        //private void statusUpdater()
        //{
        //    if (_bitExact != null)
        //    {
        //        while (_bitExact.RunStatus < 100)
        //        {                    
        //            _runStatus = _bitExact.RunStatus;
        //            Thread.Sleep(TIME_TO_CHECK_RUN_STATUS);
        //        }
        //        _runStatus = _bitExact.RunStatus;
        //        _res.setBitExact(_bitExact.Results);
        //        _runStatus = _bitExact.RunStatus;
        //        _bitExact = null;
        //        _bitExactThread = null;                
        //    }
        //}


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
