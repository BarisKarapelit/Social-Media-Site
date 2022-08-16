using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social_Media_Site.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager category = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        public ActionResult Index()
        {
            var categoryvalues = category.GetList();
            categoryvalues = categoryvalues.Where(p => p.CategoryStatus == true).ToList();
            ViewBag.categoryvalues = categoryvalues;
            return View();
        }
    }
}