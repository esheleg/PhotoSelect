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
    public class FeaturesLayerTest
    {
        [TestMethod]
        public void TestLoadingImages()
        {
            string path = @"C:\Users\Yossi\Pictures\בית''ר\מחנה סוכות 16-18.9\";
            string[] pathes = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            bool[] feat = new bool[4];
            Task task = new Task(pathes.ToList(), feat);
            FeaturesLayer core = new FeaturesLayer(ref task);
            Thread t = new Thread(core.loadImages);
            t.Start();
            while (core.LoadingImagesStatus < 100)
            {
                Debug.WriteLine("{0}", core.LoadingImagesStatus);

                Thread.Sleep(100);
            }
            Debug.WriteLine("{0}", core.LoadingImagesStatus);
            Assert.IsTrue(100 == core.LoadingImagesStatus);
            //Thread.Sleep(10000);

        }
        [TestMethod]
        public void TestRunBitExact()
        {
            string path = @"C:\Users\Yossi\Pictures\בית''ר\מחנה סוכות 16-18.9\";
            string[] pathes = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            bool[] feat = new bool[4];
            feat[(int)Feature.BIT_EXACT] = true;
            Task task = new Task(pathes.ToList(), feat);
            FeaturesLayer core = new FeaturesLayer(ref task);
            Thread t = new Thread(core.loadImages);
            t.Start();
            t.Join();            
            t = new Thread(core.run);
            t.Start();
            while (core.RunStatus < 100)
            {
                Thread.Sleep(100);
                Debug.WriteLine("{0}", core.RunStatus);
            }
            // here we will call runBitExat
            
        }

    }
}
