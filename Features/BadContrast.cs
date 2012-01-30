using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using AForge.Math; // Histogram
using Bitmap = System.Drawing.Bitmap;

namespace Features
{

    public class BadContrast
    {
        private ImageInfo[] images;
        private List<string> matches;
        private int num_images;
        private const int BRIGHT = 200;
        private const int DARK = 90;
        private int runStatus;

        protected BadContrastRes results;

        public int RunStatus
        {
            get { return runStatus; }
        }

        public BadContrast(ImageInfo[] images)
        {
            this.images = images;
            matches = new List<string>();
            num_images = images.Length;
        }

        

        public void run()
        {
        
            for (int i = 0; i < num_images; i++)
            {
                Histogram hist = images[i].getHist();
                //for each image check if is bad contrast
                if (isBadContrast(hist))
                    matches.Add(images[i].getPath()); //if is bad contrast add to matches


                runStatus = (int)Math.Round(((i + 1) / (float)num_images) * 100);
            }
            runStatus = 100;
            results = new BadContrastRes(matches);
            
        }

        public BadContrastRes Results
        {
            get { return results; }
        }


        private bool isBadContrast(Histogram hist) //mathod return true if image is bad contrast
        {
 
            int range; //num of pixels in range
            int max = getMaxValue(hist); // index of maximum point


            if (max < 20) // check range [0,20]
                range = pixelRange(hist, 0, 20);
            else if (max > 235) // check range [235,255]
                range = pixelRange(hist, 235, 255);
            else // check range [max-20,max+20]
                range = pixelRange(hist, max - 20, max + 20);

            double parcent = (double)range / (double)hist.TotalCount * 100; //parcent of range from image
            if (parcent > 70) // if is biggest than 70% return bad contrast
                return true;
            

            double bright = (double)pixelRange(hist, 235, 255) / (double)hist.TotalCount * 100; //bright parcent
                       
            if (max < 20 && parcent + bright > 70 ) // if max is dark and the rest picture is bright return bad contrast
                return true;
            

            double dark = (double)pixelRange(hist, 0, 35) / (double)hist.TotalCount * 100; // dark parcent

            if (max > 240 && dark + parcent > 70) // id max is bright and the rest picture is dark return bad contrast
                return true;
            
            return false; // picture not bad contrast

        }


        private int getMaxValue(Histogram hist) // return pixele index with maximum point
        {
            int max = -1; //init
            int index = 0;//init
            for (int i = 0; i < 255; i++)
                if (hist.Values[i] > max)
                {
                    max = hist.Values[i];
                    index = i;
                }
            return index;
        }


        private int pixelRange(Histogram hist,int start, int end) //return sum of pixeles in range [start,end]
        {
            int sum = 0;
            for (int i = start; i < end; i++)
                sum += hist.Values[i];
            return sum;
        }
    }
}
