using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitmap = System.Drawing.Bitmap;

namespace Features
{
    class BitExact
    {
        # region class properties

        // AROUND defines relative error
        //Propotion defines photo's size type 
        //checkedImages: true if we find a match otherwise false
        private const double AROUND = 0.05;
        private enum Propotion { p3_4 = 0, p4_3, p9_16, p16_9, pOther };

        private ImageInfo[] images;
        private bool[] checkedImages;
        private int numImages;
        private Propotion[] propotions;
        private int indexList;

        private List<List<string>> matches;        

        protected BitExactRes results;
        
        # endregion class properties

        # region public functions

        //default constructor, set & init variables
        public BitExact()
        {
            matches = new List<List<string>>();
            images = null;
            numImages = 0;
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
        public BitExactRes getResults()
        {
            return results;
        }

        //function that check matches
        public void run()
        {

            setPropotion(); // set propotion to images
            for (int i = 0; i < numImages; i++)
            {
                if (checkedImages[i]) //if we founded match then don't check the image
                    continue;

                bool isAddedToList = false; //check if there is match with another image
                for (int j = i + 1; j < numImages - 1; j++)
                    if (propotions[i] == propotions[j]) //check only images with similar propotions
                        isAddedToList = isAddedToList || EqualImages(i, j); //equal is true if there is a match
         
                if (isAddedToList) //if we found match to images[i] count indexList
                    indexList++;
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
            indexList = 0;
        }

        // set the propotion for each image
        private void setPropotion()
        {
            for (int i = 0; i < numImages; i++)
            {
                Bitmap im = images[i].getIm();

                if (checkPropotion(im, 3 / 4))
                    propotions[i] = Propotion.p3_4;
                else if (checkPropotion(im, 4 / 3))
                    propotions[i] = Propotion.p4_3;
                else if (checkPropotion(im, 9 / 16))
                    propotions[i] = Propotion.p9_16;
                else if (checkPropotion(im, 16 / 9))
                    propotions[i] = Propotion.p16_9;
                else
                    propotions[i] = Propotion.pOther;
            }
        }

        // check size of images, AROUND the exact point
        //return true if it similar to wantedProp
        private bool checkPropotion(Bitmap im, double wantedProp)
        {
            if ((im.Height / im.Width <= wantedProp + AROUND) && (im.Height / im.Width >= wantedProp - AROUND))
                return true;
            return false;
        }
        
        //equal images with similar propotion
        private bool EqualImages(int first, int second)
        {
            int size = images[first].getIm().Height + images[first].getIm().Width;
            int yes = 0; //count the same bites in first & second
            for (int i = 0; i < size; i++)
                if (Math.Abs(images[first].getImb()[i] - images[second].getImb()[i]) <= AROUND)
                    yes++;

            //if the success more then (95%) [100 - 100 * ARROUND] the images is eaqual
            if (yes / size >= 100 - 100 * AROUND) 
            {
                AddToResult(first, second);
                return true;
            }
            return false;
        }

        private void AddToResult(int i, int j)
        {
            //if we founded a match before add j to images i, otherwise add a new list of matches
            if (!checkedImages[i])
            {
                checkedImages[i] = true;
                matches[indexList] = new List<string>();
                matches[indexList].Add(images[i].getPath());
            }

            matches[indexList].Add(images[j].getPath());

            checkedImages[j] = true;
        }


        # endregion private functions
    }
}
