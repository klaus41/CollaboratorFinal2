using System.Web.Mvc;
using Webui;
using WebUI.Models;
using WebUI.ServiceGateway;

namespace WebUI.Controllers
{

    public class ThemesController : Controller
    {
        ThemeGateway _gateway = new ThemeGateway();

        // GET: Themes
        public ActionResult Index()
        {
            return View(_gateway.GetThemes());
        }

        public ActionResult ThemeAdmin()
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
        public ActionResult Create(Theme theme)
        {
            try
            {
                _gateway.Create(theme);

                return RedirectToAction("ThemeAdmin");
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
        public ActionResult Edit(int id, Theme theme)
        {
            try
            {
                _gateway.Edit(theme);

                return RedirectToAction("ThemeAdmin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Themes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_gateway.GetTheme(id));
        }

        // POST: Themes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _gateway.Delete(id);

                return RedirectToAction("ThemeAdmin");
            }
            catch
            {
                return View();
            }
        }
    }
}
