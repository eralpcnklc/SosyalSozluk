using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);

        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public Category GetByID(int id)
        {
            //id ye eşit mi diye kontrol edilir
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }





        //public void CategoryAddBL(Category p) 
        //{
        //    _categorydal.Insert(p);        
        
        //}
    }
}
