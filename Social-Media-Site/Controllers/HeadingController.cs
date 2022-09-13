using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace Social_Media_Site.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        private HeadingManager hm = new HeadingManager(new  EfHeadingDal());
        private WriterManager wm=new WriterManager(new EfWriterDal());
        private CategoryManager cm=new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryvalues=cm.GetList();
            var writervalues=wm.GetList();
            var headingvalues = hm.GetList();
            ViewBag.CategoryValues=categoryvalues;
            ViewBag.HeadingValues = headingvalues;
            ViewBag.WriterValues=writervalues;
            var fullName = "";
            for (int i = 0; i < headingvalues.Count; i++)
            {
                for (int j = 0; j < writervalues.Count; j++)
                {
                    if (headingvalues[i].WriterID==writervalues[j].WriterID)
                    {
                        fullName=writervalues[j].WriterName+" "+writervalues[j].WriterSurName;
                    }
                }
            }
            ViewData["fullName"]=fullName;
            return View();

            
        }
    }
}