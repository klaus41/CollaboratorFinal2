﻿using System.Web.Mvc;
using Webui;
using Webui.ServiceGateway;

namespace WebUI.Controllers
{

    public class ThemesController : Controller
    {
        EmailGateway _gateway = new EmailGateway();

        // GET: Themes
        public ActionResult Index()
        {
            return View(_gateway.GetThemes());
        }

        // GET: Themes/Details/5
        public ActionResult Details(int id)
        {
            return View(_gateway.GetTheme(id));
        }

        // GET: Themes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Themes/Create
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

        // GET: Themes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Themes/Edit/5
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

        // GET: Themes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Themes/Delete/5
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
