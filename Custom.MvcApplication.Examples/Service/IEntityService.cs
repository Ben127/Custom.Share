using Custom.MvcApplication.Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.MvcApplication.Examples.Service
{
    public interface IEntityService
    {

        IEnumerable<UserModel> GetUsers();

    }
}