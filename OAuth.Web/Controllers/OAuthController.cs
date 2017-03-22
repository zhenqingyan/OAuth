using OAuth.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OAuth.Web.Controllers
{
    public class OAuthController : ApiController
    {
        private UserApp _userApp;
        public OAuthController()
        {
            //_userApp = userApp;
            _userApp = AutoFacExt.GetFromFac<UserApp>();
        }
        [HttpGet]
        public string GetValue()
        {
            var result = _userApp.Insert(new Facade.UserVm
            {
                CreateTime = DateTime.Now,
                Creator = "Yan",
                IsDel = 0,
                IsValid = 0,
                LogonName = "Yan",
                Modifier = "Yan",
                RowGuid = Guid.NewGuid().ToString(),
                UpdateTime = DateTime.Now,
                UserName = "Yan",
                UserPassword = "123456"
            }) ? "true" : "false";
            return result;
        }
    }
}