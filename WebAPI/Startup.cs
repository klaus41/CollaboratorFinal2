using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
<<<<<<< HEAD
using WebAPI.EmailManager;
using WebAPI.Models;
=======
using DAL;
>>>>>>> 04eae6104b6a40a9be4195c22af14e48e731b2d3

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public partial class Startup
    {
        Facade _facade = new Facade();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            _facade.ThreadManager.Start();
        }


    }
}