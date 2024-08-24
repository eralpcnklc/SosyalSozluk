using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList() 
        { 
            //kategoridaki veriler gelicek
           var categoryValues = cm.GetList(); 
           return View(categoryValues);
    
        }
        [HttpGet]//sayfa yuklendigi zaman calisacak
        public ActionResult AddCategory()
        {
            return View();
        }




        [HttpPost] //sayfada butona tiklandiginda sen bu calisicak
        public ActionResult AddCategory(Category p) 
        {
           // cm.CategoryAddBL(p);
            return RedirectToAction("GetCategoryList");
        }
    }
}