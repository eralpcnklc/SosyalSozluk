using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _icontactdal;

        public ContactManager(IContactDal icontactdal)
        {
            _icontactdal = icontactdal;
        }

        public void ContactAdd(Contact contact)
        {
            _icontactdal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _icontactdal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _icontactdal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return _icontactdal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _icontactdal.List();
        }
    }
}
