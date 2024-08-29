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
    public class ContentManager : IContentService
    {
        IContentDal _icontentdal;

        public ContentManager(IContentDal icontentdal)
        {
            _icontentdal = icontentdal;
        }

        public void AddContent(Content content)
        {
            _icontentdal.Insert(content);
        }

        public void DeleteContent(Content content)
        {
            _icontentdal.Delete(content);
        }

        public void EditContent(Content content)
        {
            _icontentdal.Update(content);
        }

        public Content GetByID(int id)
        {
            return _icontentdal.Get(x=>x.ContentID==id);
        }

        public List<Content> GetContentList()
        {
            return _icontentdal.List();
        }

        public List<Content> GetListByID(int id)
        {
            return _icontentdal.List(x=>x.HeadingID==id);
        }
    }
}
