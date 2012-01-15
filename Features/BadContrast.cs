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

        protected BadContrastRes results;

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
                double mean = hist.Mean;
                double median = hist.Median;
                double sd = hist.StdDev;
               /* Debug.WriteLine(images[i].getPath());
                Debug.WriteLine("sd is: "+sd);
                Debug.WriteLine("median is: "+median);
                Debug.WriteLine("mean is: " +mean);*/
                if (isBadContrast(mean, median, sd))
                {
                    matches.Add(images[i].getPath());
                    Debug.WriteLine(images[i].getPath());
                    //Debug.WriteLine(sd);
                }
            }
            results = new BadContrastRes(matches);
        }

        public BadContrastRes Results
        {
            get { return results; }
        }

        private bool isBadContrast(double mean, double median, double sd)
        {
            /*if (mean < DARK && median < DARK)
                return true;

            if (mean > BRIGHT && median > BRIGHT)
                return true;*/
            if(sd<=15)
                return true;
            if ((mean > 200 && median > 200) || (mean < 90 && median < 90))
                return true;
            return false;
        }
    }
}
