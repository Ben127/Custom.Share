using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.ImageViewVisualizer), typeof(VisualizerObjectSource), Target = typeof(Bitmap), Description = "Image Visualizer v1.0")]
namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public class ImageViewVisualizer : BaseDebuggerVisualizer
    {
        protected override void Show(Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService windowService, Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider objectProvider)
        {
            Image image = (Image)objectProvider.GetObject();
            ImageView imageViewer = new ImageView();
            imageViewer.SetImage(image);
            windowService.ShowDialog(imageViewer);
        }
    }
}
