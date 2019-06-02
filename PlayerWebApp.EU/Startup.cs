using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(PlayerWebApp.EU.Startup))]
namespace PlayerWebApp.EU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             // ConfigureAuth(app);
        }


    }
}
