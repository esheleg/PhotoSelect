using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Features
{
    public enum Feature { BIT_EXACT = 0, BAD_CONTRAST, SIMILARITY, PARTIAL_BLOCKAGE, NUM_FEATURES };
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
    
    public class FeaturesLayer
    {
        private Task task;
        //private List<string> pathList;

        public FeaturesLayer(Task task)
        {
            this.task = task;
        }

        public void setTask(Task task)
        {
            this.task = task;
        }


    }


}
