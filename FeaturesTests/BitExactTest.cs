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
    [TestClass]
    public class BitExactTest
    {
        public const string PATH = @"C:\Users\Yossi\Dropbox\Project\BitExact Pictures\";
        string[] pathes = Directory.GetFiles(PATH, "*.jpg", SearchOption.AllDirectories);

        [TestMethod]
        public void TestBitExactLoadPictures()
        {
            int numImages = pathes.Length;
            ImageInfo[] images = new ImageInfo[numImages];
            
            for (int i = 0; i < numImages; i++)
                images[i] = new ImageInfo(pathes[i]);
           
        //    int w=24, j=22;
            BitExact be = new BitExact(images);
          //  Debug.WriteLine("{0} \n {1}", images[w].getPath(), images[j].getPath());
            be.run();
            Debug.WriteLine("{0}", "OK!!!");
                
        }

        
    }
}


