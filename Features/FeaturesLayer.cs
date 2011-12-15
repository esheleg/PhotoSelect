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
    public struct Task
    {        
        public List<string> ImagePathes
        {
            get { return ImagePathes; }
            set { ImagePathes = value; }
        }
        public bool[] Features
        {
            get { return Features; }
            set { Features = value; }
        }        
    }
    /// <summary>
    /// // this is the struct that will be returned after the BitExact Feature process is ended
    /// </summary>
    public struct BitExactRes
    {
        public List<List<string>> Matches
        {
            get { return Matches; }
            set { Matches = value; }
        }
    }
    
    public class FeaturesLayer
    {
        private Task task;        

        public FeaturesLayer(Task task)
        {
            this.task = task;
        }

        public void setTask(Task task)
        {
            this.task = task;
        }

        private void runBitExact()
        {
            // here we will call the bitExactFeature with the task images
        }


    }


}
