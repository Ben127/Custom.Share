using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// MediaHelper
    /// </summary>
    public class MediaHelper
    {

        public static MediaFile GetMediaInfo(string path)
        {
            var inputFile = new MediaFile { Filename = path };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }
            return inputFile;

        }


        public static void Convert(string inFilePath, string outFilePath)
        {
            var inputFile = new MediaFile { Filename = inFilePath };
            var outputFile = new MediaFile { Filename = outFilePath };

            using (var engine = new Engine())
            {
                engine.Convert(inputFile, outputFile);
            }
        }


    }
}
