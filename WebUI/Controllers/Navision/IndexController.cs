using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ServiceGateway;

namespace WebUI.Controllers.Navision
{
    public class IndexController : Controller
    {
        ThemeGateway _themeGateway = new ThemeGateway();
        SearchCriteriaGateway _scGateway = new SearchCriteriaGateway();
        ThemeManagerModel tm;

        // GET: Index
        public ActionResult Index()
        {
            tm = new ThemeManagerModel();
            tm.searchCriterias = _scGateway.GetSearchCriterias();
            tm.themes = _themeGateway.GetThemes();

            return View(tm);
        }
    }
}