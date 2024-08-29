using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager ab = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            return View();
        }
    }
}