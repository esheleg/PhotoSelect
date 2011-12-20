﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using Bitmap = System.Drawing.Bitmap;
using System.Diagnostics;

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
            setPropotion(); // set propotion to images
            for (int i = 0; i < numImages-2; i++)
            {
                if (checkedImages[i] || (propotions[i] == Propotion.pOther)) //if we founded match then don't check the image 
                {
                    runStatus = (int)Math.Round(((i + 1) / (float)numImages) * 100);
                    continue;
                }
                Debug.WriteLine("{0}", numImages);
                   for (int j = i + 1; j <= numImages-1 ; j++)
                    if (propotions[i] == propotions[j] && (!checkedImages[j])) //check only images with similar propotions
                        equalImages(i, j); //equal is true if there is a match


                
                    
                runStatus = (int)Math.Round(((i + 1) / (float)numImages) * 100);
                Debug.WriteLine("{0}", "After");
            }
            // set results
            results = new BitExactRes(matches);
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
            ImageInfo temp1 = images[first], temp2 = images[second];

            int size = similarSizes(first, second);
            
            byte[] firstA = images[first].getImb();
            byte[] secondA = images[second].getImb();
            
            int sum = 0; 
            
            for (int i = 0; i < size; i++)
                sum += Math.Abs(firstA[i] - secondA[i]);

            images[first] = temp1;
            images[second] = temp2;

            bool temp = false;
            //if the success more then (95%) [100 - 100 * ARROUND] the images is eaqual
            if (sum  <= 100*AROUND*size )
            {
                Debug.WriteLine("{0}", "is equal!!!");
                Debug.WriteLine("{0} \n {1}", images[first].getPath(), images[second].getPath());
                Debug.WriteLine("{0}", "****************");
                AddToResult(first, second);
                temp = true;
            }

            if (!temp)
            {
                Debug.WriteLine("{0}", "unequal !!");
                Debug.WriteLine("{0} \n {1}", images[first].getPath(), images[second].getPath());
                Debug.WriteLine("{0}", "****************");
            }
            


        }

        private int similarSizes(int first, int second)
        {
            int size = images[first].Height * images[first].Width;
            int size2 = images[second].Height * images[second].Width;

            
            if (size / size2 != 1)
            {
                if (size2 < size)
                {
                    images[first] =
                        new ImageInfo(images[first], new Size(images[second].Height, images[second].Width));
                    return size2;
                }
                else
                {
                    images[second] =
                         new ImageInfo(images[second], new Size(images[first].Height, images[first].Width));
                    return size;
                }
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
