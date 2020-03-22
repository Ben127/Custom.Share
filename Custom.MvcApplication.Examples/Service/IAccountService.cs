using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.MvcApplication.Examples.Service
{
    /// <summary>
    /// IAccount
    /// </summary>
    public interface IAccountService
    {
        bool Login(string userName, string password, Func<bool> appendFunc);

    }
}
