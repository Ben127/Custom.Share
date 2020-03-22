using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.MvcApplication.Examples.Service
{
    public class AccountService : IAccountService
    {
        private IEntityService entityService;
        public AccountService(IEntityService _entityService)
        {
            this.entityService = _entityService;
        }

        public bool Login(string userName, string password, Func<bool> appendFunc)
        {
            var loginResult = entityService.GetUsers().FirstOrDefault(p => p.UserName == userName && p.Password == password);
            if (loginResult == null)
                return false;

            return true;
        }


    }
}