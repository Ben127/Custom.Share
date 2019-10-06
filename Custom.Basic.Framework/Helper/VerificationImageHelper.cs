using AForge;
using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// VerificationImageHelper
    /// </summary>
    public class VerificationImageHelper
    {

        public static List<Bitmap> CutImages(string path, Action<Bitmap> act = null)
        {
            Bitmap sourceBitmap = (Bitmap)AForge.Imaging.Image.FromFile(path);
            Bitmap targetBitmap = (Bitmap)sourceBitmap.Clone();
            if (!AForge.Imaging.Image.IsGrayscale(targetBitmap))
            {
                targetBitmap = AForge.Imaging.Image.Clone(targetBitmap, PixelFormat.Format24bppRgb);
                targetBitmap = Grayscale.CommonAlgorithms.BT709.Apply(targetBitmap);
            }

            if (act == null)
            {
                targetBitmap = new Threshold(50).Apply(targetBitmap);
                Invert filter = new Invert();
                filter.ApplyInPlace(targetBitmap);

                BlobsFiltering bolbsfilter = new BlobsFiltering();
                bolbsfilter.CoupledSizeFiltering = true;
                bolbsfilter.MinWidth = 4;
                bolbsfilter.MinHeight = 4;
                bolbsfilter.ApplyInPlace(targetBitmap);

                Closing binary = new Closing();
                targetBitmap = binary.Apply(targetBitmap);
                filter.ApplyInPlace(targetBitmap);
            }
            else
            {
                act(targetBitmap);
            }


            var bit1 = Crop_Y(targetBitmap);
            var bit2 = Crop_X(bit1);
            return ToResizeAndCenterIt(bit2);

        }


        public static Bitmap CutImagesJoinAll(string path, Action<Bitmap> act = null)
        {
            var bitmaps = CutImages(path, act);

            //
            int paddingwidth = 2;
            int width = bitmaps.Sum(p => p.Width) + (bitmaps.Count - 2) * paddingwidth;
            int height = bitmaps.Max(p => p.Height) + 10;

            var bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            int index = 0;
            foreach (var v in bitmaps)
            {
                int x = index * v.Width;
                x = x > 0 ? x + paddingwidth : x;
                g.DrawImage(v, new Rectangle(x, 5, v.Width, v.Height));

                index++;
            }

            g.Dispose();

            return bitmap;
        }


        /// <summary>
        /// 按照 Y 轴线 切割
        /// </summary>
        private static List<Bitmap> Crop_Y(Bitmap b)
        {
            var result = new List<Bitmap>();
            int[] cols = new int[b.Width];
            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    var pixel = b.GetPixel(x, y);

                    if (pixel.R == 0)
                    {
                        cols[x] = ++cols[x];
                    }
                }
            }

            int left = 0, right = 0;

            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i] > 0 || (i + 1 < cols.Length && cols[i + 1] > 0))
                {
                    if (left == 0)
                    {
                        left = i;
                    }
                    else
                    {
                        right = i;
                    }
                }
                else
                {
                    if ((left > 0 || right > 0))
                    {
                        Crop corp = new Crop(new Rectangle(left, 0, right - left + 1, b.Height));

                        var small = corp.Apply(b);
                        result.Add(small);
                    }

                    left = right = 0;
                }
            }

            return result;
        }

        /// <summary>
        /// 按照 X 轴线 切割
        /// </summary>
        private static List<Bitmap> Crop_X(List<Bitmap> list)
        {
            var result = new List<Bitmap>();
            foreach (var segb in list)
            {
                int[] rows = new int[segb.Height];
                for (int y = 0; y < segb.Height; y++)
                {
                    for (int x = 0; x < segb.Width; x++)
                    {
                        var pixel = segb.GetPixel(x, y);
                        if (pixel.R == 0)
                        {
                            rows[y] = ++rows[y];
                        }
                    }
                }

                int bottom = 0, top = 0;

                for (int y = 0; y < rows.Length; y++)
                {
                    if (rows[y] > 0 || (y + 1 < rows.Length && rows[y + 1] > 0))
                    {
                        if (top == 0)
                        {
                            top = y;
                        }
                        else
                        {
                            bottom = y;
                        }
                    }
                    else
                    {
                        if ((top > 0 || bottom > 0) && bottom - top > 0)
                        {
                            Crop corp = new Crop(new Rectangle(0, top, segb.Width, bottom - top + 1));
                            var small = corp.Apply(segb);
                            result.Add(small);
                        }
                        top = bottom = 0;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 重置图片的指定大小并且居中
        /// </summary>
        private static List<Bitmap> ToResizeAndCenterIt(List<Bitmap> list, int w = 20, int h = 20)
        {
            List<Bitmap> result = new List<Bitmap>();

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = new Invert().Apply(list[i]);

                int sw = list[i].Width;
                int sh = list[i].Height;
                Crop corpFilter = new Crop(new Rectangle(0, 0, w, h));

                list[i] = corpFilter.Apply(list[i]);
                list[i] = new Invert().Apply(list[i]);
                int centerX = (w - sw) / 2;
                int centerY = (h - sh) / 2;
                list[i] = new CanvasMove(new IntPoint(centerX, centerY), Color.White).Apply(list[i]);

                result.Add(list[i]);
            }

            return result;
        }


    }
}
