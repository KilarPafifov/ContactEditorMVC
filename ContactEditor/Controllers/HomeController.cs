using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactEditor.Models;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using ContactEditor.Util;

namespace ContactEditor.Controllers
{
    public class HomeController : Controller
    {
        ContactContext context = new ContactContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetContacts()
        {
            var contacts = context.Contacts.ToList();
            
            return View(contacts);
        }
        
        [HttpPost]
        public ActionResult AddImage(Contact contact, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = "/Content/Images/" + System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath(fileName));
                contact.ContactId = 1 + (context.Contacts.Count());
                contact.PathToImage = fileName;
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult GetImage()
        {
            string path = "../Content/Images/jp.jpg";
            return new ImageResult(path);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult DeleteContact(string id)
        {
            ViewBag.Id = Convert.ToInt32(id);
           // int Id = Convert.ToInt32(id);
            if (ViewBag.Id > context.Contacts.Count() || ViewBag.Id <= 0)
            {
                return View();
            }

            foreach (Contact c in context.Contacts)
            {
                if (ViewBag.Id == c.ContactId)
                {
                    context.Contacts.Remove(c);
                    context.SaveChanges();
                }
            }

            return View();
        }
        public ActionResult Contact(string id)
        {
            return View();
        }
    }
}