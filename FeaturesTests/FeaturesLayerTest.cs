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
        FeaturesLayer core = null;
        Thread loadingImagesT = null;
        Thread bitExactT = null;
        public void SetupCoreBitExact()
        {
            if (core != null)
            {
                core.Dispose();
            }
            string path = @"C:\Users\Daniel\Desktop\iPhone Photos\";
            string[] pathes = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            bool[] feat = new bool[4];
            feat[(int)Feature.BIT_EXACT] = true;
            Task task = new Task(pathes.ToList(), feat);
            core = new FeaturesLayer(ref task);
        }
        public void SetupCoreAndLoadImagesBitExact()
        {
            SetupCoreBitExact();
            loadingImagesT = new Thread(core.loadImages);
            loadingImagesT.Start();
            loadingImagesT.Join();

        }

        [TestMethod]
        public void TestLoadingImages()
        {
            string path = @"C:\Users\Daniel\Desktop\iPhone Photos\";
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
            string path = @"C:\Users\Daniel\Desktop\iPhone Photos\";
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
        [TestMethod]
        public void TestResultsStructure()
        {
            Results res = new Results();
            List<List<string>> lst = new List<List<string>>(10);
            for (int i = 0; i < 10; i++)
            {
                lst.Add(new List<string>(10));
                for (int j = 0; j < 10; j++)
                {
                    lst.Last().Add("afdasdasd");
                }
            }
            BitExactRes bRes = new BitExactRes(lst);
            res.setBitExact(bRes);
            foreach (List<string> ll in res.BitExact.Matches)
            {
                foreach (string str in ll)
                    Debug.WriteLine(str + " ");
            }
            List<List<string>> l = res.BitExact.Matches;
                    
           
        }
        [TestMethod]
        public void TestDisposeInLoadingImages()
        {            
            // testing stopping in the middle
            SetupCoreBitExact();
            loadingImagesT = new Thread(core.loadImages);
            loadingImagesT.Start();
            Thread.Sleep(2000);
            Debug.WriteLine("load state before Dispose: {0}", core.LoadingImagesStatus);
            core.Dispose();           
            // testing in the end of loading images
            SetupCoreAndLoadImagesBitExact();            
            core.Dispose();       
        }
        [TestMethod]
        public void TestDisposeInBitExactRun()
        {
            SetupCoreAndLoadImagesBitExact();
            bitExactT = new Thread(core.run);
            bitExactT.Start();
            Thread.Sleep(1000);
            Debug.WriteLine("State: {0}", core.RunStatus);
            Debug.WriteLine("{0}", bitExactT.IsAlive);
            core.Dispose();           
            if (bitExactT.IsAlive)
                Assert.IsTrue(0 == 1);
            Debug.WriteLine("{0}", bitExactT.IsAlive);

        }

    }
}
