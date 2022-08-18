using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social_Media_Site.Controllers
{
    public class StatisticsCategoryController : Controller
    {
        CategoryManager category = new CategoryManager(new EfCategoryDal());
        // GET: StatisticsCategory
        public ActionResult Index()
        {
            var categoryvalues = category.GetList();
            var categoryQuantity = categoryvalues.Count();
            ViewBag.categoryQuantity = categoryQuantity;
            List<SelectListItem> Test = (categoryvalues.Where(p => p.CategoryName == "Giyim")).ToList();
          //  var yazilim = categoryvalues.Where(p => p.CategoryName == "Giyim").ToList();
            ViewBag.yazilim = yazilim;
            return View();
        }
        
    }
}