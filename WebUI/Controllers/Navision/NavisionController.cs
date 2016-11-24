using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebUI.ServiceGateway;

namespace WebUI.Controllers.Navision
{
    public class NavisionController : Controller
    {
        NavisionGateway _gateway = new NavisionGateway();

        // GET: Navision
        public ActionResult Index()
        {
            try
            {
                return View(_gateway.GetContacts());
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("401"))
                    return RedirectToAction("Login", "Account", new { returnUrl = Request.Url.LocalPath });

                ViewBag.Error = ex.Message;
                return View("Error");
            }

        }
    }
}