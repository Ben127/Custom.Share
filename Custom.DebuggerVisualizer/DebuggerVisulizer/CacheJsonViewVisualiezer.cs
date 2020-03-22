using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CacheJsonViewVisualiezer), typeof(VisualizerObjectSource), Target = typeof(string), Description = "Cache JSON Visualizer v1.0")]

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public class CacheJsonViewVisualiezer : BaseDebuggerVisualizer
    {
        protected override void Show(Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService windowService, Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider objectProvider)
        {
            string content = objectProvider.GetObject().ToString();

            if (!string.IsNullOrEmpty(content))
            {
                var content2 = new Regex(@"\s{2,}|\r\n").Replace(content, "");
                content2 = new Regex(@"\\").Replace(content2, "");
                content2 = new Regex(@"""{").Replace(content2, "{");
                content2 = new Regex(@"}""").Replace(content2, "}");

                content = content2;
            }

            JsonView form = new JsonView(content);
            windowService.ShowDialog(form);
        }
    }
}

