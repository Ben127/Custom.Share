using Custom.DebuggerVisualizer.V12.DebuggerVisulizer;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Custom.DebuggerVisualizer.V12Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DictionaryTest();

            Console.ReadKey();
        }

        static void ImageTest()
        {
            var bitmap = Image.FromFile(@"D:\Temp\img1.jpg");
            VisualizerDevelopmentHost host = new VisualizerDevelopmentHost(bitmap, typeof(ImageViewVisualizer));
            host.ShowVisualizer();
        }

        static void JsonTest()
        {
            string json = @"{""FileId"": ""1111111111111111111"",""Video"": {""Url"": ""123.mp3"",""Verify_Content"": ""cfhyQNKY+123=""},""Code"": 0,""Message"": """",""CodeDesc"": ""Success""}";
            VisualizerDevelopmentHost host2 = new VisualizerDevelopmentHost(json, typeof(JsonViewVisualizer));
            host2.ShowVisualizer();
        }

        static void DictionaryTest()
        {
            Dictionary<string, Test> dict = new Dictionary<string, Test>()
            {
                {"天河区",new Test()},
                {"越秀区",new Test()},
                {"荔湾区",new Test()},
                {"白云区",new Test()},
            };

            VisualizerDevelopmentHost host = new VisualizerDevelopmentHost(dict, typeof(DictionaryViewVisualizer));
            host.ShowVisualizer();
        }

        [Serializable]
        public class Test
        {

        }

    }
}
