using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager( new EFHeadingDal());
        ContentManager contentmanager = new ContentManager(new EFContentDal());
        Context context = new Context();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeadings(string p) 
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = hm.GetByEmailID(p);
            var contentValues = hm.GetListByWriter(writeridinfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valueCategory;
            return View();  
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            var p = (string)Session["WriterMail"];
            var writeridinfo = hm.GetByEmailID(p);
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).
                                                      ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeadings");
        }

        public ActionResult ContentByHeadingID(int id)
        {
            var contentValues=  contentmanager.GetListByID(id);
            return View(contentValues);

        }

        public ActionResult AllHeadings(int p = 1) {

            var allheadings = hm.GetList().ToPagedList(p, 4);
            return View(allheadings); 
        }
    }
}