using System.Diagnostics; // for using Debug

// default
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//---------
//using System.Drawing; //Bitmap
using AForge.Imaging;
using AForge.Imaging.Filters; // Convolution
using AForge.Math; // Histogram

using Bitmap = System.Drawing.Bitmap;
using Size = System.Drawing.Size;
using BitmapData = System.Drawing.Imaging.BitmapData;
using Rectangle = System.Drawing.Rectangle;

namespace Features
{
    public class ImageInfo : IDisposable
    {

        # region consts      

        // thie image processed area will allways be <= PROC_IMAGE_AREA        
        public static readonly int MAX_IMAGE_AREA = 320 * 240;
        public static readonly int MAX_GRAY_VALUE = 255;
        // the used ratio for each color channel in converting rgb to gray (R,G,B)
        public static readonly Grayscale GRAY_FILTER = new Grayscale(0.2989, 0.5870, 0.1140);

        # endregion consts

        # region static functions

        /// <summary>
        /// runs a two dimentional convolution on im,
        /// where f is im and g is filter
        /// </summary>
        /// <param name="im">f(t)</param>
        /// <param name="kernel">g(u-t)</param>
        /// <returns>a new instance of ImageInfo</returns>
        public static ImageInfo conv2(ImageInfo im, int[,] kernel)
        {
            
            ImageInfo convIm = new ImageInfo(im.getIm());
            Convolution filter = new Convolution(kernel);
            filter.ApplyInPlace(convIm.getIm());

            return convIm;

        }                                
            

        /// <summary>
        /// writes a jpg formated image to path
        /// </summary>
        public static void writeImage(string path, Bitmap im)
        {
            try
            {
                im.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// writes a jpg formated image from imInfo.getIm() into imInf.getPath()
        /// ****** IF EXISTS, WILL OVERWRITE THE imInf.getPath() image *******
        /// </summary>
        /// <param name="imInf">the wanted image to save im imInf.getPath() </param>
        public static void writeImage(ImageInfo imInf)
        {writeImage(imInf.getPath(), imInf.getIm());}
        /// <summary>
        /// writes a jpg formated image from imInfo.getIm() into path
        /// ****** IF EXISTS, WILL OVERWRITE THE image in path*******
        /// </summary>
        /// <param name="imInf">the wanted image to save im imInf.getPath() </param>
        public static void writeImage(ImageInfo imInf, string path)
        {writeImage(path, imInf.getIm());}

        # endregion static functions

        # region Class Properties

        private float[] _imf;
        private Histogram _hist; // AForge.Math.Histogram
        private Bitmap _imGray; // System.Drawing.Bitmap
        private string _path; //holds the full path to the image        
        private byte[] _imb;
        private int _width;
        private int _height;

        private bool _disposed;


        # endregion **************************Class Properties*********************

        #region Read Only Properties

        public int Width {get { return _width; }}

        public int Height { get { return _height; } }

        #endregion Read Only Properties


        # region public functions
        public ImageInfo(string path)
        {
            _disposed = false;

            _hist = null;
            _imf = null;
            _imb = null;
            _height = _width = 0;
            this._path = path;
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(this._path);
                
                oirgIm2grayCropped(image); // creates _imGray
                image.Dispose();

                _width = _imGray.Width;
                _height= _imGray.Height;
            }
            catch (Exception e) { throw e; }
        }
        public ImageInfo(ImageInfo origIm, Size newSize)
        {
            _disposed = false;

            _imGray = new Bitmap(origIm.getIm(), newSize);
            _hist = null;
            _imf = null;
            _imb = null;
            _path = null;
            _width = newSize.Width;
            _height = newSize.Height;

        }
        public string getPath() { return _path;}
        public Bitmap getIm()
        {
            return _imGray;
        }
        public Histogram getHist()
        {
            return _hist != null ? _hist : createHist();
        }
        public float[] getImF()
        {
            return _imf != null ? _imf : createImf();
        }
        public byte[] getImb()
        {
            return _imb != null ? _imb : createImb();
        }
        /// <summary>
        /// Runs a 2dim conv with kernel, saves res in getIm() and sets null to all 
        /// other properties.
        /// </summary>
        public void conv2(int[,] kernel)
        {
            Convolution filter = new Convolution(kernel);
            filter.ApplyInPlace(_imGray);            
        }

        # endregion public functions

        # region private functions

        /// <summary>
        /// this construr gets the _imGray of an ImageInfo in order to get another object
        /// of that image without any more data, can be used when running filters on images
        /// </summary>
        /// <param name="imGray"></param>
        private ImageInfo(Bitmap imGray)
        {
            _disposed = false;

            _path = null;
            _hist = null;
            _imf = null;
            _imGray = (Bitmap)imGray.Clone();
            _width = _imGray.Width;
            _height = _imGray.Height;

        }
        /// <summary>
        /// convers the image into a grayscaled bimap with an area <MAX_IMAGE_AREA
        /// </summary>
        /// <param name="image"></original image type>
        public void oirgIm2grayCropped(System.Drawing.Image image)
        {
            Bitmap origImCropped = new Bitmap(image, croppedSize(image.Size));            
            _imGray = GRAY_FILTER.Apply(origImCropped);
        }

        /// <summary>
        /// finds the propper width and height that will save the image proportion
        /// and will have an area <= MAX_IMAGE_AREA
        /// </summary>
        public Size croppedSize(Size origSize)
        {
            int origSizeArea = origSize.Width*origSize.Height;            
            // if the orig area is smaller than PROC_IMAGE_AREA
            if (origSizeArea < MAX_IMAGE_AREA) {
                return origSize;
            }

            Size newSize = new Size();
            float imageRatio = (float)origSize.Width/origSize.Height;
            newSize.Height = (int)Math.Sqrt(MAX_IMAGE_AREA / imageRatio);
            newSize.Height -= newSize.Height % 2;
            newSize.Width = (int)(newSize.Height * imageRatio);
            newSize.Width -= newSize.Width % 2;
            return newSize;
        }
        /// <summary>
        /// **** THIS FUNCTION CAN BE CALLED ONLY ONES IN THE OBJECT LIFE TIME***
        /// creates an AForge.Math.Histogram object from _imGray into _hist
        /// </summary>
        private Histogram createHist()
        {
            if (_hist != null) return _hist;
            _hist = (new ImageStatistics(_imGray)).Gray;            
            return _hist;
        }
        /// <summary>
        /// **** THIS FUNCTION CAN BE CALLED ONLY ONES IN THE OBJECT LIFE TIME***
        /// creates an array with _imGray pixel values normalized(1) and saves it in _imf(float[])
        /// </summary>
        private float[] createImf()
        {
            if (_imf != null) return _imf;

            // get image data (for the raw data pointer)
            BitmapData imGrayData = 
                _imGray.LockBits(new Rectangle(0,0, _imGray.Width, _imGray.Height),
                                System.Drawing.Imaging.ImageLockMode.ReadOnly, 
                                _imGray.PixelFormat);
            _imf = new float[_imGray.Width * _imGray.Height];
            // copy image gray val's into normalized float (0.....1)
            unsafe
            {
                for (int i = 0; i < imGrayData.Height; i++)
                {
                    byte* row = (byte*)imGrayData.Scan0 + (i * imGrayData.Stride);
                    for (int j = 0; j < imGrayData.Width; j++)
                    {
                        _imf[i * imGrayData.Width + j] = (float)row[j]/MAX_GRAY_VALUE;
                    }

                }
            }
            return _imf;
        }
        /// <summary>
        /// **** THIS FUNCTION CAN BE CALLED ONLY ONES IN THE OBJECT LIFE TIME***
        /// creates an AForge.Math.Histogram object from _imGray into _hist
        /// </summary>
        private byte[] createImb()
        {
            if (_imb != null) return _imb;

            // get image data (for the raw data pointer)
            BitmapData imGrayData =
                _imGray.LockBits(new Rectangle(0, 0, _imGray.Width, _imGray.Height),
                                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                _imGray.PixelFormat);
            _imb = new byte[_imGray.Width * _imGray.Height];
            // copy image gray val's into normalized float (0.....1)
            unsafe
            {
                for (int i = 0; i < imGrayData.Height; i++)
                {
                    byte* row = (byte*)imGrayData.Scan0 + (i * imGrayData.Stride);
                    for (int j = 0; j < imGrayData.Width; j++)
                    {
                        _imb[i * imGrayData.Width + j] = row[j];
                    }

                }
            }
            return _imb;
        }
        # endregion public functions    
    
        #region ***************IDisposable*******************

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // TODO - check if the arrays can be disposed somehow wthout massing the GC work flow
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _imGray.Dispose();
                    _imGray = null;
                    _imb = null;
                    _imf = null;
                    _hist = null;
                }
                _disposed = true;
            }          
        }

        ~ImageInfo()
        {
            Dispose(false);
        }


        #endregion ***************IDisposable*******************
    }
}
