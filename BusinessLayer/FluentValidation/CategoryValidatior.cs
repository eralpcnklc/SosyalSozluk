using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x =>x.CategoryName).NotEmpty().WithMessage("Kategori adini bos gecemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori aciklamasini bos gecemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen en az 3 karakter girisi yapin");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lutfen 20 karakterden fazla deger girisi yapmayiniz");
        }
    }
}
