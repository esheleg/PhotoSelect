using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        
        private ImageInfo[] _images;

        # region (GUI <-> BRAIN) shared data

        private int _loadingImagesStatus; // read only
        private Task _task;

        #endregion

        public FeaturesLayer(ref Task task)
        {
            _task = task;
            _loadingImagesStatus = 0;
            _images = new ImageInfo[task.ImagePathes.Count];
        }        

        # region (GUI --> BRAIN) Methods
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
        /// </summary>
        public void loadImages()
        {
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
        #endregion (GUI --> BRAIN) Methods

        private void runBitExact()
        {
            // here we will call the bitExactFeature with the task images
        }


    }


}
