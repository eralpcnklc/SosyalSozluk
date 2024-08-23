using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCatagoryList() 
        { 
            //kategoridaki veriler gelicek
            var categoryValues = cm.GetAllBl(); 
            return View(categoryValues);
    
        }
    }
}