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
        private const int DARK = 50;
        
        public BadContrast(ImageInfo [] images)
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
                double mean = hist.Mean;
                double median = hist.Median;
                //Debug.WriteLine(mean);
                //Debug.WriteLine(images[i].getPath());

                if (isBadContrast(mean,median))
                {
                    matches.Add(images[i].getPath());
                    Debug.WriteLine(images[i].getPath());
                }
            }    
        }

        private bool isBadContrast(double mean, double median)
        {
            if (mean < DARK && median < DARK)
                return true;
            
            if (mean > BRIGHT && median > BRIGHT)
                return true;
            
            return false;
        }
    }
}
