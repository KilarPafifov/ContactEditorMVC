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

        public ActionResult GetSortedContacts()
        {
            var contacts = context.Contacts.OrderBy(u => u.Person).ToList();
            return View(contacts);
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact, HttpPostedFileBase upload)
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

        [HttpGet]
        public ActionResult EditContact(int id)
        {
            ViewBag.ContactId = id;
            return View();
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact, HttpPostedFileBase upload)
        {
            foreach(Contact c in context.Contacts)
            {
                if (upload != null)
                {
                    if (c.ContactId == contact.ContactId)
                    {
                        string fileName = "/Content/Images/" + System.IO.Path.GetFileName(upload.FileName);
                        upload.SaveAs(Server.MapPath(fileName));
                        c.Person = contact.Person;
                        c.Phone = contact.Phone;
                        c.PathToImage = fileName;
                    }
                }
            }

            context.SaveChanges();
            return View();
        }
        
        public ActionResult DeleteContact(string id)
        {
            ViewBag.Id = Convert.ToInt32(id);
           
            if (ViewBag.Id > context.Contacts.Count() || ViewBag.Id <= 0)
            {
                return View();
            }

            foreach (Contact c in context.Contacts)
            {
                if (ViewBag.Id == c.ContactId)
                {
                    context.Contacts.Remove(c);
                }
            }

            context.SaveChanges();
            return View();
        }
        public ActionResult Contact(string id)
        {
            return View();
        }
    }
}