using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PickROI
{
    public class ImageProcessing
    {
        public void Image2Array(Bitmap in_image, ref byte[] bgrArray)
        {
            // 배열 초기화
            Array.Clear(bgrArray, 0, bgrArray.Length);

            Rectangle rect = new Rectangle(0, 0, in_image.Width, in_image.Height);

            // 이미지 포멧 변환 항상 24비트 rgb 형태로 (그래이 포함)
            var image = new Bitmap(in_image.Width, in_image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using(var gr = Graphics.FromImage(image))
            {
                gr.DrawImage(in_image, rect);
            }

            System.Drawing.Imaging.BitmapData bmpData;

            bmpData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * image.Height;

            byte[] tmpArray = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, tmpArray, 0, bytes);

            image.UnlockBits(bmpData);

            for (int j = 0; j < image.Height; j++)
            {
                int index = j * Math.Abs(bmpData.Stride);
                int index1 = j * image.Width * 3;
                Array.Copy(tmpArray, index, bgrArray, index1, image.Width * 3);
            }

            tmpArray = null;
        }

        public Bitmap CropImage(Bitmap image, Rectangle cropRect)
        {

            if (image == null)
            {
                return null;
            }

            Bitmap cropImage = new Bitmap(image);
            cropImage = cropImage.Clone(cropRect, cropImage.PixelFormat);

            return cropImage;
        }
   
    }

}
