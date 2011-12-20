using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
namespace Features
{
    public enum Feature { BIT_EXACT = 0, BAD_CONTRAST, SIMILARITY, PARTIAL_BLOCKAGE, NUM_FEATURES };

    /// <summary>
    /// // this struct will recieve the task information from the gui
    /// </summary>
    /// 
    # region (GUI --> BRAIN) Structures
    public struct Task
    {
        private List<string> _pathes;
        private bool[] _features;        

        public Task(List<string> pathes, bool[] feauters)
        {
            _pathes = pathes;
            _features = feauters;
        }

        public List<string> ImagePathes
        {
            get { return _pathes; }
        }
        public bool[] Features
        {
            get { return _features; }
        }

    }
    /// <summary>
    /// // this is the struct that will be returned after the BitExact Feature process is ended
    /// </summary>
    public struct BitExactRes
    {
        private List<List<string>> _matches;

        public BitExactRes(List<List<string>> matches)
        {
            _matches = new List<List<string>>(matches.Count);
            foreach (List<string> lst in matches)
            {
                matches.Add(new List<string>(lst.Count));
                foreach (string path in lst)
                {
                    matches.Last().Add(path);
                }
            }
        }
        public List<List<string>> Matches
        {            
            get { return _matches; }            
        }
    }
    #endregion
    
    public class FeaturesLayer
    {
        /// <summary>
        /// the time that the statusUpdater will check the RunStatus of the features
        /// </summary>
        static readonly int TIME_TO_CHECK_RUN_STATUS = 1000; // [ms]
        
        private ImageInfo[] _images;        

        private BitExact _bitExact;
        private Thread _bitExactThread;

        private Thread _statusUpdaterThread;

        private int _loadingImagesStatus; // read only        
        private int _runStatus; // read only
        private Task _task;               

        public FeaturesLayer(ref Task task)
        {
            _bitExactThread = null;
            _bitExact = null;
            _loadingImagesStatus = 0;
            _runStatus = 0;
            _task = task;
            _images = new ImageInfo[task.ImagePathes.Count];
        }        

        # region (GUI <--> BRAIN) Methods
                    
        /// <summary>
        /// range: 0-100, returns the completion % of the loadImages() method
        /// </summary>
        /// 
        public int LoadingImagesStatus
        {
            get { return _loadingImagesStatus; }
        }
        /// <summary>
        /// sets the array of ImageInfo and creates the objects
        /// thorws exception if ocures on one of the images
        /// </summary>
        public void loadImages()
        {// TODO - check if you can classify the possible exceptions (for continuing even if one image fails)
            for (int i = 0; i < _images.Length; i++)
            {
                try
                {                                     
                    _images[i] = new ImageInfo(_task.ImagePathes[i]);
                }
                catch (Exception e)
                {                    
                    throw e;
                }
                _loadingImagesStatus = (int)(((float)(i + 1) / _images.Length) * 100);
            }

        }

        /// <summary>
        /// Get the RunStatus of the running features
        /// </summary>
        public int RunStatus
        {
            get { return _runStatus; }
        }
        /// <summary>
        /// This will be called in a different thread, 
        /// It will start the features run and the statusUpdater
        /// </summary>
        public void run()
        {
            if (_task.Features[(int)Feature.BIT_EXACT])
            {
                Debug.WriteLine("BitExact");
                _bitExact = new BitExact(_images);
                _bitExactThread = new Thread(_bitExact.run);
                _bitExactThread.Start();
            }

            _statusUpdaterThread = new Thread(statusUpdater);
            _statusUpdaterThread.Start();

        }
        #endregion (GUI --> BRAIN) Methods


        /// <summary>
        /// This will update (in diff thread)  _runStatus;
        /// </summary>
        private void statusUpdater()
        {
            if (_bitExact != null)
            {
                while (_bitExact.RunStatus < 100)
                {                    
                    _runStatus = _bitExact.RunStatus;
                    Thread.Sleep(TIME_TO_CHECK_RUN_STATUS);
                }
                _runStatus = _bitExact.RunStatus;
                _bitExact = null;
                _bitExactThread = null;
            }
        }        


    }


}
