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
        
        public BadContrast(ImageInfo [] images)
        {
            this.images = images;
            matches = new List<string>();
            num_images = images.Length;
        }

        public void run()
        {
            Histogram x = images[0].getHist();
            double m = x.StdDev;
            Debug.WriteLine(m);
        }
    }
}
