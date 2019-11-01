using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace Custom.DebuggerVisualizer
{
    /// <summary>
    ///  自定义调试器基类
    /// </summary>
    public abstract class BaseDebuggerVisualizer : DialogDebuggerVisualizer
    {
        /// <summary>
        /// Debug 调试
        /// </summary>
        /// <typeparam name="Visualizer"></typeparam>
        /// <typeparam name="ObjectSource"></typeparam>
        /// <param name="objectToVisualize"></param>
        public static void TestShowVisualizer<Visualizer, ObjectSource>(object objectToVisualize)
            where Visualizer : class
            where ObjectSource : class
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(Visualizer),
                typeof(ObjectSource));
            visualizerHost.ShowVisualizer();
        }

    }
}
