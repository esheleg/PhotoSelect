using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Features
{
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
        public Task(Task from) : this(from.ImagePathes, from.Features) { }

        public Task(List<string> pathes, bool[] feauters)
        {

            // copy pathes
            _pathes = new List<string>(pathes.Count);
            foreach (string path in pathes)
                _pathes.Add(path);
            // copy features flags
            _features = new bool[feauters.Length];
            feauters.CopyTo(_features, 0);
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
        private BadContrastRes _badContrastRes;
        
        public BitExactRes BitExact
        {
            get { return _bitExactRes; }
        }
        public void setBitExact(BitExactRes bitExactRes)
        {
            _bitExactRes = new BitExactRes(bitExactRes.Matches);
        }
        public void setBadContrast(BadContrastRes badContrast)
        {
            _badContrastRes = new BadContrastRes(badContrast.Matches);
        }
        public BadContrastRes BadContrast
        {
            get { return _badContrastRes; }
        }
    }
    #endregion ******************(GUI <--> BRAIN) Structures********************
}
