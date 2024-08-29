using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class Contact : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}