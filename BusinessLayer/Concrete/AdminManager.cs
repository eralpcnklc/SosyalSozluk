using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;
        public void AddAdmin(Admin admin)
        {
            _admindal.Insert(admin);
        }

        //public void Authentication(Admin admin)
        //{
        //    Context context = new Context();
        //    var adminuserinfo = context.Admins.FirstOrDefault(x=>x.AdminUsername==admin.AdminUsername&&x.AdminPassword==admin.AdminPassword);
        //    if (adminuserinfo !=null)
        //    {
                
        //    }
        //}

        public void AdminDelete(Admin admin)
        {
            _admindal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _admindal.Update(admin);
        }

        public void Authentication(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            return _admindal.Get(x=>x.AdminID==id);
        }

        public List<Admin> GetList()
        {
            return _admindal.List();
        }
    }
}
