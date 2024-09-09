using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: 
        
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());
        public ActionResult Headings() {
            var headingList = hm.GetList();
            return View(headingList);
        }
  
        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.GetListByID(id);
            return PartialView(contentList);
        }
    }
}