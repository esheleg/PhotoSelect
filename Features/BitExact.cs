using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using Bitmap = System.Drawing.Bitmap;

namespace Features
{
    public class BitExact
    {
        # region class properties

        // AROUND defines relative error
        //Propotion defines photo's size type 
        //checkedImages: true if we find a match otherwise false
        private const double AROUND = 0.05;
        private enum Propotion { p3_4=0 , p4_3, p9_16, p16_9, pOther };

        private ImageInfo[] images;
        private bool[] checkedImages;
        private int numImages;
        private Propotion[] propotions;
              

        private List<List<string>> matches;        

        protected BitExactRes results;

        private int runStatus;
        public int RunStatus
        {
            get { return runStatus; }
        }
        
        # endregion class properties

        # region public functions

        //default constructor, set & init variables
        public BitExact(ImageInfo[] images)
        {
            matches = new List<List<string>>();
            setImages(images);            
        }

        //set path of images, and set relevant variables
        public void setImages(ImageInfo[] images)
        {
            this.images = images;
            numImages = images.Length;
            initResults();
            checkedImages = new bool[numImages];
            propotions = new Propotion[numImages];
            
        }

        //this is the struct function that will be returned after the BitExact Feature process is ended
        public BitExactRes Results
        {
            get { return results; }
        }

        //function that check matches
        public void run()
        {
            try
            {
                setPropotion(); // set propotion to images
                for (int i = 0; i < numImages - 2; i++)
                {
                    if (checkedImages[i] || (propotions[i] == Propotion.pOther)) //if we founded match then don't check the image 
                    {
                        runStatus = (int)Math.Round(((i + 1) / (float)numImages) * 100);
                        continue;
                    }
                    for (int j = i + 1; j <= numImages - 1; j++)
                        if (propotions[i] == propotions[j] && (!checkedImages[j])) //check only images with similar propotions
                            equalImages(i, j); //equal is true if there is a match




                    runStatus = (int)Math.Round(((i + 1) / (float)numImages) * 100);

                }
                runStatus = 100;
                // set results
                results = new BitExactRes(matches);
            }       
            catch (ThreadAbortException)
            { // ResetAbout() handles and the exception and letting the thread 
              // finish normally (reaching the end of the function)
                Thread.ResetAbort();              
            }          
        }

        # endregion public functions




        # region private functions

        //empty matches
        private void initResults()
        {
            matches = new List<List<string>>();
            
        }

        // set the propotion for each image
        private void setPropotion()
        {
            for (int i = 0; i < numImages; i++)
            {
                double p = images[i].Height / images[i].Width;
                if (checkPropotion(p, 9 / 16))
                    propotions[i] = Propotion.p9_16;
                else if (checkPropotion(p, 16 / 9))
                    propotions[i] = Propotion.p16_9;
                else if (checkPropotion(p, 3 / 4))
                    propotions[i] = Propotion.p3_4;
                else if (checkPropotion(p, 4/3))
                    propotions[i] = Propotion.p4_3;
                else  
                    propotions[i] = Propotion.pOther;



            }
        }

       
        // check size of images, AROUND the exact point
        //return true if it similar to wantedProp
        private bool checkPropotion(double prop, double wantedProp)
        {
            if ((prop <= wantedProp + AROUND) && (prop >= wantedProp - AROUND))
                return true;
            return false;
        }

       
        //equal images with similar propotion
        public void equalImages(int first, int second)
        {
            ImageInfo temp1=null, temp2=null;

            int size = similarSizes(out temp1,out temp2, first, second);
            
            byte[] firstA = temp1.getImb();
            byte[] secondA = temp2.getImb();
            
            int sum = 0; 
            
            for (int i = 0; i < size; i++)
                sum += Math.Abs(firstA[i] - secondA[i]);

            
            //if the success more then (95%) [100 - 100 * ARROUND] the images is eaqual
            if (sum <= 100 * AROUND * size)
                AddToResult(first, second);
                  

           
        }


        private int similarSizes(out ImageInfo first,out  ImageInfo second, int i, int j)
        {
            int size = images[i].Height * images[i].Width;
            int size2 = images[j].Height * images[j].Width;


            if (size / size2 != 1)
            {
                if (size2 < size)
                {
                    first = new ImageInfo(images[i], new Size(images[j].Width, images[j].Height));
                    second = new ImageInfo(images[j], new Size(images[j].Width, images[j].Height));
                    return size2;
                }
                else
                {
                    first = new ImageInfo(images[i], new Size(images[i].Height, images[i].Width));
                    second = new ImageInfo(images[j], new Size(images[i].Height, images[i].Width));
                    return size;
                }
            }
            else
            {
                first = new ImageInfo(images[i], new Size(images[i].Height, images[i].Width));
                second = new ImageInfo(images[j], new Size(images[i].Height, images[i].Width));
            }
            return size;
        }
   
        private void AddToResult(int i, int j)
        {
            //if we founded a match before add j to images i, otherwise add a new list of matches
            if (!checkedImages[i])
            {
                checkedImages[i] = true;
                matches.Add( new List<string>());
                matches.Last().Add(images[i].getPath());
            }

            matches.Last().Add(images[j].getPath());

            checkedImages[j] = true;
        }
        
        # endregion private functions
    }
}
