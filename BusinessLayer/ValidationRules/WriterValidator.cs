﻿using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<WriterCityViewModel>
    {
        public WriterValidator(string geciciSifre)
        {
            RuleFor(x => x.Writers.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.Writers.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.Writers.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");//en az bir büyük, küçük, sayı
            RuleFor(x => x.Writers.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifrenizin içinde en az bir büyük karakter içerdiğinden emin olun");
            RuleFor(x => x.Writers.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifrenizin içinde en az bir küçük karakter içerdiğinden emin olun");
            RuleFor(x => x.Writers.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifrenizin içinde en az bir numara içerdiğinden emin olun");
            RuleFor(x => x.Writers.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.Writers.WriterPassword).Equal(geciciSifre).WithMessage("Şifreler Uyuşmuyor");
        }
    }
}