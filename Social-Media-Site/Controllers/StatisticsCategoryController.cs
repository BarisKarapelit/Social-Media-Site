using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        HeadingManager heading = new HeadingManager(new EfHeadingDal());
        Context context = new Context();
        public ActionResult Index()
        {
            var categoryvalues = category.GetList();
            var headingvalues = heading.GetList();
            var categoryQuantity = categoryvalues.Count();
            ViewBag.categoryQuantity = categoryQuantity;
            foreach (var category in categoryvalues)
            {
                if (category.CategoryName=="Yazılım")
                {
                    var value = headingvalues.Where(x => x.CategoryID == category.CategoryID);
                    ViewBag.value = value.Count();
                }
            }
            var value3 = context.Writers.Where(n => n.WriterName.Contains("a") || n.WriterName.Contains("A")).Count();
            ViewBag.value3 = value3;

            var value4 = context.Categories.Where(u => u.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
              .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.value4 = value4;

            DateTime bugunTarihi = DateTime.Now.Date;
            DateTime sinavTarihi = new DateTime(2022, 8, 08);

            TimeSpan ts = bugunTarihi-sinavTarihi;
            ViewBag.ts = ts.Days.ToString();

            var value5 = context.Categories.Where(n => n.CategoryStatus == true).Count() - context.Categories.Where(n => n.CategoryStatus == false).Count();
            ViewBag.value5 = value5;
            return View();
        }
        
    }
}