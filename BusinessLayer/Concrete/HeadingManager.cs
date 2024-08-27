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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _hd;
        ICategoryDal _categorydal;

        public Category GetByID(int id)
        {
            //id ye eşit mi diye kontrol edilir
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public int FindByCategory(string st)
        {
            //List<int> l = new List<int>();
            int count = 0;
            var hdlist = _hd.List();
            foreach (var hd in hdlist)
            {
                var catID = hd.CategoryID;
                var catName = GetByID(catID).CategoryName;
                if (catName == st)
                { 
                    count++;
                }
            }
            return count;
        }

    }
}
