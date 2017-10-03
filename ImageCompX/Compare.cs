using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompX
{
    class Compare
    {
        public static Bitmap CompareImages(Bitmap img1, Bitmap img2)
        {
            Bitmap bitmap = new Bitmap(img1.Width, img1.Height);

            for (int x = 0; x < img1.Width; x++)
            {
                if (x >= img2.Width) continue;

                for (int y = 0; y < img1.Height; y++)
                {
                    if (y >= img2.Height) continue;

                    Color a = img1.GetPixel(x, y);
                    Color b = img2.GetPixel(x, y);

                    int dif = Math.Abs(a.R - b.R) + Math.Abs(a.G - b.G) + Math.Abs(a.B - b.B);

                    float normalized = (float)dif / 765f;

                    byte red = (byte)(normalized * 255f);

                    bitmap.SetPixel(x, y, Color.FromArgb(red, 0, 0));
                }
            }

            return bitmap;
        }
    }
}