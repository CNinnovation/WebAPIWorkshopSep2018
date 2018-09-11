using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSample.Controllers
{
    [Authorize]
    public class MyDemoController : Controller
    {
        public string Index()
        {
            string user = User.Identity.Name;
            return user;
        }

        [AllowAnonymous]
        public string Allow()
        {
            return "allow all";
        }
    }
}