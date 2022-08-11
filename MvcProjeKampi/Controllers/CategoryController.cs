using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {

        CategoryManager category = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            //var categoryvalues = category.GetAll();
            //categoryvalues = categoryvalues.Where(p => p.CategoryStatus == true).ToList();
            //return View(categoryvalues);

        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            bool test = Convert.ToBoolean(p.CategoryStatus);
            string a = p.CategoryName.ToString();
            //category.CategoryAddBl(p);
            return RedirectToAction("GetCategoryList");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}