using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Features;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace FeaturesTests
{
    class BadContrastTest
    {
        public const string PATH = @"C:\Users\Maya\Dropbox\פרויקט - הנדסת תוכנה\badContrast";
        string[] pathes = Directory.GetFiles(PATH, "*.jpg", SearchOption.AllDirectories);

        [TestMethod]
        public void TestBadContrast()
        {
            int numImages = pathes.Length;
            ImageInfo[] images = new ImageInfo[numImages];
            for (int i = 0; i < numImages; i++)
            {
                images[i] = new ImageInfo(pathes[i]);
            }

            BadContrast bc;
            bc = new BadContrast(images);
            bc.run();
        }
    
    
    
    }
}
