using Custom.MvcApplication.Examples.Models;
using Custom.MvcApplication.Examples.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.MvcApplication.Examples.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private readonly IAccountService accoutService;
        public AccountController(IAccountService _accountService)
        {
            this.accoutService = _accountService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public JsonResult LoginPost(LoginModel model)
        {
            if (accoutService.Login(model.UserName, model.Password, () => { return true; }))
            {
                return Json("ok");
            }

            return Json("fail");
        }

    }
}
