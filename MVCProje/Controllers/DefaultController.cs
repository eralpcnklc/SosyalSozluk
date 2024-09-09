using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        public ActionResult Headings() {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}