using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Pinvoke
{
    /// <summary>
    /// WninetExtension
    /// </summary>
    public class WininetExtension
    {
        /// <summary>
        ///  网络状态
        /// </summary>
        /// <param name="lpdwFlags"></param>
        /// <param name="dwReserved">默认0</param>
        /// <returns></returns>
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetConnectedState(out InternetGetConnectedStateFlags lpdwFlags, int dwReserved);


    }
}

