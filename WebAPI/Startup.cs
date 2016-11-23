using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using DAL;

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
