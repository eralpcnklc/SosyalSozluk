using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class İstatistik : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            return View(cm);
        }

        public ActionResult CategoryCount()
        {
            return View();
        }


    }
}