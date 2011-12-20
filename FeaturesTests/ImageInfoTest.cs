using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Features;
using System.Drawing;
using System.IO;
using System.Threading;
namespace FeaturesTests
{
    [TestClass]
    public class ImageInfoTest
    {
        public const string PATH_160_120_RGB = @"C:\Users\Daniel\Pictures\PhotoSelect\160_120.jpg";
        public const string PATH_485_405_RGB = @"C:\Users\Daniel\Pictures\PhotoSelect\indexed.jpg";
        public const string PATH_TEST_RES = @"C:\Users\Daniel\Pictures\PhotoSelect\testRes.jpg";
        public const string PATH_TEST_RES0 = @"C:\Users\Daniel\Pictures\PhotoSelect\testRes0.jpg";
        public const string PATH_TEST_RES1 = @"C:\Users\Daniel\Pictures\PhotoSelect\testRes1.jpg";
        [TestMethod]
        public void TestCroppedSize()
        {
            ImageInfo imInf = new ImageInfo(PATH_160_120_RGB);
            // test when size < PROC_IMAGE_SIZE
            Size testSize = new Size(160, 120);
            Size newSize = imInf.croppedSize(testSize);
            Size wantedSize = new Size(160, 120);
            Assert.AreEqual(wantedSize,newSize);
            Console.WriteLine("wantedArea: {0}, newArea: {1}, newSize: {2}, origSize: {3}",
                wantedSize.Height*wantedSize.Width,newSize.Height*newSize.Width, newSize, testSize);       
            // test when size > PROC_IMAGE_SIZE
            testSize = new Size(640, 480);
            newSize = imInf.croppedSize(testSize);
            wantedSize = new Size(320, 240);
            Console.WriteLine("wantedArea: {0}, newArea: {1}, newSize: {2}, origSize: {3}",
                wantedSize.Height * wantedSize.Width, newSize.Height * newSize.Width, newSize, testSize);       
            Assert.IsTrue(wantedSize.Height*wantedSize.Width >= newSize.Height*newSize.Width);
            testSize = new Size(1920, 1080);
            newSize = imInf.croppedSize(testSize);
            wantedSize = new Size(320, 240);
            Console.WriteLine("wantedArea: {0}, newArea: {1}, newSize: {2}, origSize: {3}",
                wantedSize.Height * wantedSize.Width, newSize.Height * newSize.Width, newSize, testSize);       
            Assert.IsTrue(wantedSize.Height * wantedSize.Width >= newSize.Height * newSize.Width);
            testSize = new Size(1600, 900);
            newSize = imInf.croppedSize(testSize);
            wantedSize = new Size(320, 240);
            Console.WriteLine("wantedArea: {0}, newArea: {1}, newSize: {2}, origSize: {3}",
                wantedSize.Height * wantedSize.Width, newSize.Height * newSize.Width, newSize, testSize);       
            Assert.IsTrue(wantedSize.Height * wantedSize.Width >= newSize.Height * newSize.Width);


        }
        [TestMethod]
        public void TestoirgIm2grayCropped()
        {
            ImageInfo imInf = new ImageInfo(PATH_485_405_RGB);
            Bitmap gray = imInf.getIm();
            ImageInfo.writeImage(PATH_TEST_RES, gray);
            Console.WriteLine("oirgIm2grayCropped results are in testRes.jpg\n");            
        }
        [TestMethod]
        public void TestgetHist()
        {
            ImageInfo imInf = new ImageInfo(PATH_160_120_RGB);
            AForge.Math.Histogram hist = imInf.getHist();
            Console.WriteLine("{0} {1} {2} {3} {4} {5}\n", hist.Max, hist.Min, hist.Mean, hist.StdDev,
                hist.TotalCount, hist.Median);

            int[] histVal = hist.Values;
            for (int i = 0; i < histVal.Length; i++)
            {
                Console.Write("{0} ", histVal[i]);
            }
        }
        [TestMethod]
        public void TestgetImf()
        {
            ImageInfo im = new ImageInfo(PATH_160_120_RGB);

            float[] imf = im.getImF();
            Console.WriteLine(" {0} {1} {2} {3}\n", imf.Length, im.getIm().Width * im.getIm().Height,
                imf.Min(), imf.Max());
            Assert.IsTrue(imf.Max() <= 1 && imf.Min() >= 0 &&
                imf.Length == (im.getIm().Width * im.getIm().Height));
        }

        [TestMethod]
        public void TestConv2()
        {
            int[,] kernel = {
            { 1, 1,  1 },
            { 1,  0,  1 },
            {  1,  1,  1 } };

            ImageInfo imOrig = new ImageInfo(PATH_485_405_RGB);
            ImageInfo convIm = ImageInfo.conv2(imOrig, kernel);
            ImageInfo.writeImage(convIm, PATH_TEST_RES);
            ImageInfo.writeImage(imOrig, PATH_TEST_RES0);
            Console.WriteLine("{0} {1}", imOrig.getIm().Height, imOrig.getIm().Width);
            Console.WriteLine("{0} {1}", convIm.getIm().Height, convIm.getIm().Width);
            imOrig.conv2(kernel);
            ImageInfo.writeImage(imOrig, PATH_TEST_RES1);
            Console.WriteLine("{0} {1}", imOrig.getIm().Height, imOrig.getIm().Width);

        }

        [TestMethod]
        public void TestgetImb()
        {
            ImageInfo im = new ImageInfo(PATH_160_120_RGB);
            byte[] imb = im.getImb();

            for (int i = 0; i < im.getIm().Width; i++)
            {
                for (int j = 0; j < im.getIm().Height; j++)
                {
                    Console.Write("{0} ", imb[i * im.getIm().Height + j]);
                }
                Console.WriteLine();
            }
        }
        [TestMethod]
        public void TestImageInfoCopyResizeConstructor()
        {
            string path = @"C:\Users\Yossi\Dropbox\Project\BitExact Pictures\pic450X800.jpg";
            ImageInfo origIm = new ImageInfo(path);
            ImageInfo origIm2 = new ImageInfo(origIm, new Size(origIm.Width/2, origIm.Height/2));
            ImageInfo.writeImage(origIm, @"C:\Users\Yossi\Dropbox\Project\BitExact Pictures\" + "orig.jpg");
            ImageInfo.writeImage(origIm2, @"C:\Users\Yossi\Dropbox\Project\BitExact Pictures\" + "orig2.jpg");

        }

    }
}
