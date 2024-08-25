using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;



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
            CategoryValidatior cv = new CategoryValidatior();
            ValidationResult validationResult = cv.Validate(p);//result isminde degisken cvden gelen degerlere gore kontrol yap
            if (validationResult.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }
            else 
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}