using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social_Media_Site.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager category = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = category.GetList();
            categoryvalues = categoryvalues.Where(p => p.CategoryStatus == true).ToList();
            ViewBag.categoryvalues = categoryvalues;
            Console.WriteLine(categoryvalues);
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                category.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            category.CategoryAddBl(p);
            return RedirectToAction("GetCategoryList");
            
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}