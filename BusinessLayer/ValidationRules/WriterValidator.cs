using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adın En az 2 karakter giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar Adın En fazla 50 karakter girebilirsiniz");


            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Açıklaması Boş Geçemezsiniz");

            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Yazar Soyadı En az 2 karakter giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar Soyadı En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Açıklaması Boş Geçemezsiniz");
        }
    }
}
