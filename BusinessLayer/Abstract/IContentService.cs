using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetListByID(int id);
        void AddContent (Content content);
        void DeleteContent(Content content);
        void EditContent(Content content);

    }
}
