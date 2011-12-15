using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Features
{
    class BitExact
    {       
        private ImageInfo[] images;
        private bool[] checkedImages;
        private int numImages;

        protected BitExactRes results;

        public BitExact()
        {
            images = null;
            numImages = 0;
        }

        public void setImages(ImageInfo[] images)
        {
            this.images = images;
            numImages = images.Length;
            initResults();
            checkedImages = new bool[numImages];            
            

        }

        private void initResults()
        {
            // divided by two because this is the max number of bitExact images
            results.Matches = new List<List<string>>();            

        }

        public BitExactRes getResults()
        {
            return results;
        }

        public void run()
        {
            for (int i = 0; i < numImages; i++)
            {
                if (checkedImages[i])
                    continue;


            }
        }



    }
}
