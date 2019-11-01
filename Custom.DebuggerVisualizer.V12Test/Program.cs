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
            //ImageTest();
            //JsonTest();
            DictionaryTest();
            //ICollectionTest();

            Console.ReadKey();
        }

        static void ImageTest()
        {
            var bitmap = Image.FromFile(@"C:\Users\Benny\Desktop\保存图\new_douyin.png");
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
            CollectionViewVisualizer.TestShowVisualizer<CollectionViewVisualizer, CollectionObjectSource>(dict);

            //VisualizerDevelopmentHost host = new VisualizerDevelopmentHost(dict, typeof(CollectionViewVisualizer));
            //host.ShowVisualizer();
        }


        static void ICollectionTest()
        {
            List<Test> result = new List<Test>()
            {
                new Test{  Id=DateTime.Now.Second, Name=Guid.NewGuid().ToString()}
            };

            VisualizerDevelopmentHost host = new VisualizerDevelopmentHost(result, typeof(CollectionViewVisualizer));
            host.ShowVisualizer();

        }

        [Serializable]
        public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}
