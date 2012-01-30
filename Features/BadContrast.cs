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
                //double mean = hist.Mean;
                //double median = hist.Median;
                //double sd = hist.StdDev;
                //long size = hist.TotalCount;
                if (isBadContrast(hist))
                    matches.Add(images[i].getPath());


                runStatus = (int)Math.Round(((i + 1) / (float)num_images) * 100);
            }
            runStatus = 100;
            results = new BadContrastRes(matches);
            
        }

        public BadContrastRes Results
        {
            get { return results; }
        }

        private bool isBadContrast(Histogram hist)
        {
 
            int x;
            int max = getMaxValue(hist);


            if (max < 20)
                x = pixelRange(hist, 0, 20);
            else if (max > 235)
                x = pixelRange(hist, 235, 255);
            else
                x = pixelRange(hist, max - 20, max + 20);

            double parcent = (double)x / (double)hist.TotalCount * 100;
            if (parcent > 70)
                return true;
            

            double bright = (double)pixelRange(hist, 235, 255) / (double)hist.TotalCount * 100;
           
            
            if (max < 50 && parcent + bright > 45 )
                return true;
            

            double dark = (double)pixelRange(hist, 0, 35) / (double)hist.TotalCount * 100;

            if (max > 200 && dark + parcent > 45)
                return true;
            
            return false;

        }


        private int getMaxValue(Histogram hist)
        {
            int max = -1;
            int index = 0;
            for (int i = 0; i < 255; i++)
                if (hist.Values[i] > max)
                {
                    max = hist.Values[i];
                    index = i;
                }
            return index;
        }


        private int pixelRange(Histogram hist,int start, int end)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
                sum += hist.Values[i];
            return sum;
        }
    }
}
