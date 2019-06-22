using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.DictionaryViewVisualizer), typeof(VisualizerObjectSource), Target = typeof(IDictionary), Description = "Dictionary Visualizer v1.0")]
namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public class DictionaryViewVisualizer : BaseDebuggerVisualizer
    {
        protected override void Show(Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService windowService, Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider objectProvider)
        {
            IDictionary dictionary = (IDictionary)objectProvider.GetObject();
            DictionaryView dictionaryViewer = new DictionaryView(dictionary);
            windowService.ShowDialog(dictionaryViewer);
        }
    }
}
