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



namespace MvcProjeKampi.Controllers
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
            return View();

        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            
            //category.CategoryAddBl(p);
            CategoryValidator categoryValidator = new CategoryValidator();
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
            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}