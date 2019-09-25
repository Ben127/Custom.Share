using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Pinvoke.Enum
{
    /// <summary>
    /// UrlMkSetSessionOptionFlags
    /// </summary>
    public enum UrlMkSetSessionOptionFlags
    {
        URLMON_OPTION_USERAGENT,// = 0x10000001,       // userAgent
        INTERNET_OPTION_PROXY,      // proxy
        INTERNET_OPTION_REFRESH,    //设置确定是否可以从注册表中重新读取代理信息的值。值TRUE表示可以从注册表中重新读取代理信息。
        URLMON_OPTION_USERAGENT_REFRESH  //为此过程从注册表中刷新用户代理字符串。
    }
}
