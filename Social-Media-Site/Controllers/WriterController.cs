using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Social_Media_Site.Controllers
{
    public class WriterController : Controller
    {
        WriterValidator writerValidator = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        // GET: Writer
        public ActionResult Index()
        {
            
            var writerValues = writerManager.GetList();

            ViewBag.writerValues = writerValues.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);

            if (Request.Files.Count != 0)
            {
                string DosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //  string Uzanti = Path.GetExtension(Request.Files[0].FileName);
                string Yol = "~/img/Writer/"+writer.WriterID+ DosyaAdi;
                Request.Files[0].SaveAs(Server.MapPath(Yol));
                writer.WriterImage = Yol;

            }


            if (result.IsValid)
            {
                

                writerManager.WriterAdd(writer);
                return RedirectToAction("/Index");


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
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetByID(id);

            return View(writerValue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer, int id)
        {
            var writerValue = writerManager.GetByID(id);
            string Yol;
            if (writer.WriterImage == null)
             {
                Yol = "~/img/Writer/user1.jpg";
                writer.WriterImage = Yol;
            }
            else
            {
                Yol = "~/img/Writer/" + writer.WriterImage.ToString();
              
            }
             
            ValidationResult result = writerValidator.Validate(writer);
            if (Request.Files.Count != 0)
            {
                string DosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                if (DosyaAdi!=null&&DosyaAdi.Length > 0)
                {
                    
                    //  string Uzanti = Path.GetExtension(Request.Files[0].FileName);
                     Yol = "~/img/Writer/" + DosyaAdi;
                    Request.Files[0].SaveAs(Server.MapPath(Yol));
                    writer.WriterImage = Yol;
                }
                

            }
            if (result.IsValid)
            {
                writer.WriterImage = Yol;
                writerManager.WriterUpdate(writer);
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
        
    }
}