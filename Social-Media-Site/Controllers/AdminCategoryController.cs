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
    public class AdminCategoryController : Controller
    {
        CategoryManager category = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        [HttpGet]
        public ActionResult Index()
        {
            var categoryvalues = category.GetList();
            
            ViewBag.categoryvalues = categoryvalues;
            return View();
        }
        [HttpPost]
        public ActionResult Index( EntityLayer.Concrete.Category c,string btn )
        {
            var categoryvalues = category.GetList();
            if (btn=="Aktif")
            {
                categoryvalues = categoryvalues.Where(p => p.CategoryStatus == true).ToList();
            }
            else
            {
                categoryvalues = categoryvalues.Where(p => p.CategoryStatus == false).ToList();
            }
          
            
            
            ViewBag.categoryvalues = categoryvalues;
            return View();
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                category.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = category.GetByID(id);
            category.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = category.GetByID(id);
            return View(categoryValue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            category.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}