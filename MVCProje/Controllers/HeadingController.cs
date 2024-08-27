using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());

        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        [HttpPost]
        public ActionResult AddHeading()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        
        }
    }
}