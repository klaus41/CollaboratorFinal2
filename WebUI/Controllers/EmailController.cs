﻿using System.Net.Http;
using System.Web.Mvc;
using Webui;
using Webui.ServiceGateway;
using WebUI;

namespace WebUI.Controllers
{

    public class EmailController : Controller
    {
        EmailGateway _gateway = new EmailGateway();

        // GET: Email
        public ActionResult Index()
        {
            try
            {
                return View(_gateway.GetEmails());
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("401"))
                    return RedirectToAction("Login", "Account", new { returnUrl = Request.Url.LocalPath });

                ViewBag.Error = ex.Message;
                return View("Error");
            }

        }
        // GET: Email/Details/5
        public ActionResult Details(int id)
        {
            return View(_gateway.GetEmail(id));
        }

        // GET: Email/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Email/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Email/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
