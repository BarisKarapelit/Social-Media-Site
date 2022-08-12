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
<<<<<<< HEAD

        CategoryManager category = new CategoryManager(new EfCategoryDal());
=======
        CategoryManager category = new CategoryManager();
>>>>>>> parent of 7c76042 (Entity Framework Dal)
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
<<<<<<< HEAD
            var categoryvalues = category.GetList();
            categoryvalues = categoryvalues.Where(p => p.CategoryStatus == true).ToList();
            ViewBag.categoryvalues = categoryvalues;
            return View();

=======
            var categoryvalues = category.GetAll();
            categoryvalues = categoryvalues.Where(p => p.CategoryStatus == true).ToList();
            return View(categoryvalues);
>>>>>>> parent of 7c76042 (Entity Framework Dal)
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
<<<<<<< HEAD
            
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
=======
            category.CategoryAddBl(p);
            return RedirectToAction("GetCategoryList");
>>>>>>> parent of 7c76042 (Entity Framework Dal)
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}