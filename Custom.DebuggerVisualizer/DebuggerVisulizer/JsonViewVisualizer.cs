using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.JsonViewVisualizer), typeof(VisualizerObjectSource), Target = typeof(string), Description = "JSON Visualizer v1.0")]
namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public class JsonViewVisualizer : BaseDebuggerVisualizer
    {
        protected override void Show(Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService windowService, Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider objectProvider)
        {
            string content = objectProvider.GetObject().ToString();
            JsonView form = new JsonView(content);
            windowService.ShowDialog(form);
        }
    }
}
