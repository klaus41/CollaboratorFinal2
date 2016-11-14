using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ServiceGateway;

namespace WebUI.Controllers
{
    public class EmailAccountController : Controller
    {
        EmailAccountGateway _gateway = new EmailAccountGateway();

        public ActionResult Index()
        {
            return View(_gateway.GetEmailAccounts());
        }

        // GET: EmailAccount/Details/5
        public ActionResult Details(int id)
        {
            return View(_gateway.GetEmailAccount(id));
        }

        // GET: EmailAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailAccount/Create
        [HttpPost]
        public ActionResult Create(EmailAccount emailAccount)
        {
            try
            {
                _gateway.Create(emailAccount);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmailAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmailAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmailAccount emailAccount)
        {
            try
            {
                _gateway.Edit(emailAccount);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmailAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_gateway.GetEmailAccount(id));
        }

        // POST: EmailAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _gateway.Delete(id);
                   
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
