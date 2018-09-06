using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactEditor.Models;
using System.Data.Entity;
using System.Drawing;
using System.IO;

namespace ContactEditor.Controllers
{
    public class HomeController : Controller
    {
        ContactContext context = new ContactContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetContacts()
        {
            var contacts = context.Contacts.ToList();
            return View(contacts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}