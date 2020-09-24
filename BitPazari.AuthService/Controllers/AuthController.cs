using BitPazari.AuthService.Models;
using BitPazari.Model.Entities;
using BitPazari.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitPazari.AuthService.Controllers
{
    public class AuthController : ApiController
    {
        AppUserService _appUserService;
        public AuthController()
        {
            _appUserService = new AppUserService();
        }
        [HttpPost]
        public HttpResponseMessage Login(Credential item)
        {
            var url = "";
            if (item.UserName==null||item.Password==null)
            {
                url = "http://localhost:55697/Home/Login";
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Succes = true, RedirectUrl = url });
            }
            if (_appUserService.CheckCredentials(item.UserName,item.Password))
            {
                AppUser appUser = new AppUser();
                appUser = _appUserService.FindUserName(item.UserName);
                if (appUser.Role==Role.Admin||appUser.Role==Role.Member)
                {
                    url = $"http://localhost:55697/Home/Index/{appUser.Id}";
                    return Request.CreateResponse(HttpStatusCode.OK, new { Succes = true, RedirectUrl = url });
                }
                else
                {
                    url = $"http://localhost:55697/Home/Index";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Succes = true, RedirectUrl = url });
                }
            }
            url = "http://localhost:55697/Home/Login";
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Succes = true, RedirectUrl = url });
        }
        public HttpResponseMessage LogOut()
        {
            var url = "http://localhost:55697/Home/Index";
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Succes = true, RedirectUrl = url }); ;
        }
    }
}
