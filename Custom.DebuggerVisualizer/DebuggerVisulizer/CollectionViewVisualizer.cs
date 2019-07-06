using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.DictionaryViewVisualizer), typeof(VisualizerObjectSource), Target = typeof(ICollection), Description = "Collection Visualizer v1.0")]
namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public class CollectionViewVisualizer : BaseDebuggerVisualizer
    {
        protected override void Show(Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService windowService, Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider objectProvider)
        {
            ICollection dictionary = (ICollection)objectProvider.GetObject();
            CollectionView collectionViewer = new CollectionView(dictionary);
            windowService.ShowDialog(collectionViewer);
        }
    }
}
