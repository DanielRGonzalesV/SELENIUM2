using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace CompareUtil
{
    public class CompareUtil
    {
        public enum Result { Matched, SizeMismatch, PixelMismatch };

        public static Result CompareImage(string baseFile, string actualFile)
        {
            Result result = Result.Matched;

            Bitmap baseBmp = (Bitmap)Image.FromFile(baseFile);
            Bitmap actBmp = (Bitmap)Image.FromFile(actualFile);

            if (baseBmp.Size != actBmp.Size)
                result = Result.SizeMismatch;
            else
            {
                int height = Math.Min(baseBmp.Height, actBmp.Height);
                int width = Math.Min(baseBmp.Width, actBmp.Width);

                bool are_identical = true;
                for (int x = 0; x <= width - 1; x++)
                {
                    for (int y = 0; y <= height - 1; y++)
                    {
                        if (baseBmp.GetPixel(x, y).Equals(actBmp.GetPixel(x, y)))
                        {
                        }
                        else
                        {
                            are_identical = false;
                        }
                    }
                }
                if (are_identical == true)
                    result = Result.Matched;
                else
                    result = Result.PixelMismatch;
            }

            return result;
        }
    }
} 
