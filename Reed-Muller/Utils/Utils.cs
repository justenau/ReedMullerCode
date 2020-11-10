using System.Drawing;
using System.Drawing.Imaging;

namespace Reed_Muller.Utils
{
    public static class Utils
    {
        private static int tempFilesCount;

        /// <summary>
        /// The program takes very long time to proccess big input image so this function
        /// resizes them if the provided input image was not 1bpp bitmap and was bigger than
        /// 300x300 ratio.
        /// </summary>
        /// <param name="image">Original input image</param>
        /// <returns>Resized and compressed image</returns>
        public static Bitmap CompressImage (Bitmap image)
        {
            if((image.PixelFormat == PixelFormat.Format1bppIndexed) && image.Width<300 && image.Height<300)
            {
                return image;
            }
            (int wRatio, int hRatio) = (image.Width / 50, image.Height / 50);
            var temp = new Bitmap(image, image.Width/(wRatio>0 ? wRatio : 1), image.Height/(hRatio>0?hRatio:1));
            var resizedImage = temp.Clone(new Rectangle(0, 0, temp.Width, temp.Height), PixelFormat.Format24bppRgb);

            var tempName = tempFilesCount.ToString();
            resizedImage.Save(tempName, ImageFormat.Bmp);
            tempFilesCount++;
            return new Bitmap(tempName);
        }
    }
}
