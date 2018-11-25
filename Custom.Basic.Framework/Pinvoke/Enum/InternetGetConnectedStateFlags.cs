using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Pinvoke
{
    [Flags]
    public enum InternetGetConnectedStateFlags
    {
        /// <summary>
        /// 本地系统使用调制解调器连接到Internet。
        /// </summary>
        INTERNET_CONNECTION_MODEM = 0x01,

        /// <summary>
        /// 本地系统使用局域网连接到Internet。
        /// </summary>
        INTERNET_CONNECTION_LAN = 0x02,

        /// <summary>
        /// 代理
        /// </summary>
        INTERNET_CONNECTION_PROXY = 0x04,

        /// <summary>
        /// 本地系统已安装RAS。
        /// </summary>
        INTERNET_CONNECTION_RAS_INSTALLED = 0x10,

        /// <summary>
        /// 本地系统处于脱机模式。
        /// </summary>
        INTERNET_CONNECTION_OFFLINE = 0x20,

        /// <summary>
        /// 本地系统具有到Internet的有效连接，但它当前可能连接也可能不连接。
        /// </summary>
        INTERNET_CONNECTION_CONFIGURED = 0x40
    }
}

