using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    /// <summary>
    /// BaseVisualizerObjectSource
    /// </summary>
    public class BaseVisualizerObjectSource : VisualizerObjectSource
    {

        public override void GetData(object target, Stream outgoingData)
        {
            base.GetData(target, outgoingData);
        }

    }
}
