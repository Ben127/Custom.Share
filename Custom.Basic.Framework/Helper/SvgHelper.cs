using Svg;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// SvgHelper
    /// </summary>
    public class SvgHelper
    {

        public static bool ConvertSvg(string svgContent, string svgName = null)
        {
            var bytes = System.Text.Encoding.Default.GetBytes(svgContent);
            return ConvertSvg(bytes, svgName);
        }

        public static bool ConvertSvg(byte[] svgBytes, string svgName = null)
        {
            if (svgBytes == null || svgBytes.Count() == 0)
                return false;

            if (!string.IsNullOrEmpty(svgName))
            {
                svgName = AppDomain.CurrentDomain.BaseDirectory + "/" + DateTime.Now.Ticks.ToString() + ".svg";
            }
            string directory = Path.GetDirectoryName(svgName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                System.IO.File.WriteAllBytes(svgName, svgBytes);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }


        public static void ConvertImage(byte[] svgBytes, string imgPath)
        {

            try
            {
                string svgName = AppDomain.CurrentDomain.BaseDirectory + "svg.svg";
                if (ConvertSvg(svgBytes, svgName))
                {
                    using (var stream = new MemoryStream(svgBytes))
                    {
                        var svgDocument = SvgDocument.Open(svgName);
                        var bitmap = svgDocument.Draw();
                        bitmap.Save(imgPath, ImageFormat.Png);

                        File.Delete(svgName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
