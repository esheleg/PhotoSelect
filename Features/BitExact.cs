using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitmap = System.Drawing.Bitmap;

namespace Features
{
    class BitExact
    {
        private const double AROUND = 0.05;
        private enum Propotion { p3_4 = 0, p4_3, p9_16, p16_9, pOther };

        private ImageInfo[] images;
        private bool[] checkedImages;
        private int numImages;
        private Propotion[] propotions;
        private int indexList;


        protected BitExactRes results;

        public BitExact()
        {
            images = null;
            numImages = 0;
        }

        public void setImages(ImageInfo[] images)
        {
            this.images = images;
            numImages = images.Length;
            initResults();
            checkedImages = new bool[numImages];
            propotions = new Propotion[numImages];
        }

        private void initResults()
        {
            // first empty result
            results.Matches = new List<List<string>>();
            indexList = 0;
        }

        public BitExactRes getResults()
        {
            return results;
        }

        public void run()
        {

            setPropotion();
            for (int i = 0; i < numImages; i++)
            {
                if (checkedImages[i])
                    continue;
                bool addedToList = false;
                for (int j = i + 1; j < numImages - 1; j++)
                    if (propotions[i] == propotions[j])
                        addedToList = addedToList || EqualImages(i, j);
         
                if (addedToList)
                    indexList++;
            }
        }


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

        private bool checkPropotion(Bitmap im, double wantedProp)
        {
            if ((im.Height / im.Width <= wantedProp + AROUND) && (im.Height / im.Width >= wantedProp - AROUND))
                return true;
            return false;
        }
        

        private bool EqualImages(int first, int second)
        {
            int size = images[first].getIm().Height + images[first].getIm().Width;
            int yes = 0;
            for (int i = 0; i < size; i++)
                if (Math.Abs(images[first].getImb()[i] - images[second].getImb()[i]) <= AROUND)
                    yes++;
            if (yes / size >= 100 - 100 * AROUND)
            {
                AddToResult(first, second);
                return true;
            }
            return false;
        }

        private void AddToResult(int i, int j)
        {

            if (!checkedImages[i])
            {
                checkedImages[i] = true;
                results.Matches[indexList] = new List<string>();
                results.Matches[indexList].Add(images[i].getPath());
            }

            results.Matches[indexList].Add(images[j].getPath());

            checkedImages[j] = true;
        }
    }
}
