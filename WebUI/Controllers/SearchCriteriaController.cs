using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ServiceGateway;

namespace WebUI.Controllers
{
    public class SearchCriteriaController : Controller
    {
        SearchCriteriaGateway _gateway = new SearchCriteriaGateway();

        // GET: SearchCriteria
        public ActionResult Index()
        {
            return View(_gateway.GetSearchCriterias());
        }

        // GET: SearchCriteria/Details/5
        public ActionResult Details(int id)
        {
            return View(_gateway.GetSearchCriteria(id));
        }

        // GET: SearchCriteria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchCriteria/Create
        [HttpPost]
        public ActionResult Create(SearchCriteria sc)
        {
            try
            {
                // TODO: Add insert logic here
                _gateway.Create(sc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchCriteria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchCriteria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SearchCriteria sc)
        {
            try
            {
                // TODO: Add update logic here
                _gateway.Edit(sc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchCriteria/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_gateway.GetSearchCriteria(id));
        }

        // POST: SearchCriteria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
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
