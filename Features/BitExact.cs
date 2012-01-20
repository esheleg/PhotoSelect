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
            float realRunStatus = 0;
            try
            {                
                setPropotion(); // set propotion to images
                for (int i = 0; i < numImages - 1; i++)
                {
                    int equalToImage = 0;
                    if (checkedImages[i] || (propotions[i] == Propotion.pOther)) //if we founded match then don't check the image 
                    {                        
                        continue;
                    }
                    for (int j = i + 1; j < numImages; j++)
                        if (propotions[i] == propotions[j] && (!checkedImages[j])) //check only images with similar propotions
                        {
                            if(equalImagesFast(i, j)) //equal is true if there is a match                                
                                equalToImage++;
                        }

                    realRunStatus += (float)(1 + equalToImage) / numImages;
                    runStatus = (int)(Math.Min(Math.Round(realRunStatus*100), 99));                    
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
            Debug.Assert( (firstA.Length == secondA.Length) );
            for (int i = 0; i < size; i++)
                sum += Math.Abs(firstA[i] - secondA[i]);

            
            //if the success more then (95%) [100 - 100 * ARROUND] the images is eaqual
            if (sum <= 100 * AROUND * size)
                AddToResult(first, second);
                  

           
        }
        public bool equalImagesFast(int first, int second)
        {
                        
            ImageInfo temp1 = null, temp2 = null;            
            int size = similarSizes(out temp1, out temp2, first, second);

            int[] stripLen = new int[2];
            stripLen[0] = 2 * (int)(((AROUND * 100) / 255) * size);
            int numStrips = (int)Math.Ceiling((double)(size) / stripLen[0]);
            stripLen[1] = size - stripLen[0] * (numStrips - 1);
            

            byte[] firstA = temp1.getImb();
            byte[] secondA = temp2.getImb();

            int sum = 0;

            for (int k = 0; k < numStrips - 1; k++)
            {
                int stripEnd = (k+1)*stripLen[0];
                for (int i = k*stripLen[0]; i < stripEnd; i++)
                    sum += Math.Abs(firstA[i] - secondA[i]);
                if (sum > 100 * AROUND * size)
                    return false;
            }
            for (int i = (numStrips - 1) * stripLen[0]; i < size; i++)
                sum += Math.Abs(firstA[i] - secondA[i]);


            //if the success more then (95%) [100 - 100 * ARROUND] the images is eaqual
            if (sum <= 100 * AROUND * size)
            {
                AddToResult(first, second);
                return true;
            }


            return false;
        }


        private int similarSizes(out ImageInfo first,out  ImageInfo second, int i, int j)
        {
            int size = images[i].Height * images[i].Width;
            int size2 = images[j].Height * images[j].Width;


            if ( (double)size / size2 != 1.0)
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
                //first = new ImageInfo(images[i], new Size(images[i].Height, images[i].Width));
                //second = new ImageInfo(images[j], new Size(images[i].Height, images[i].Width));
                first = images[i];
                second = images[j];
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
