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
                double mean = hist.Mean;
                double median = hist.Median;
                double sd = hist.StdDev;
                if (isBadContrast(mean, median, sd))
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

        private bool isBadContrast(double mean, double median, double sd)
        {
            if(sd<=15)
                return true;
            if ((mean > BRIGHT && median > BRIGHT) || (mean < DARK && median < DARK))
                return true;
            return false;
        }
    }
}
