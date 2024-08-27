using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _wd;
        public int charCount(char k)
        {
            int count = 0;
            var l = _wd.List();
            foreach (var c in l)
            {
                if (c.WriterName.Contains("k"))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
