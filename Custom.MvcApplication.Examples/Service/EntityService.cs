using Custom.MvcApplication.Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.MvcApplication.Examples.Service
{
    public class EntityService : IEntityService
    {
        public IEnumerable<UserModel> GetUsers()
        {
            return new List<UserModel>
            {
                 new UserModel{ UserId=100, UserName="admin",Password="12345"},
                 new UserModel{ UserId=101, UserName="test",Password="12345"},
            };
        }
    }
}