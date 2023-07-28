using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class RecipeValidator:AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.ReceipeName).NotEmpty().WithMessage("Yemek Adı Boş Geçilemez.!");
            RuleFor(x => x.ReceipeDescription).NotEmpty().WithMessage("Yemek Açıklaması Boş Geçilemez.!");
            RuleFor(x => x.ReceipeImage).NotEmpty().WithMessage("Yemek Resmi Boş Geçilemez.!");
            RuleFor(x => x.ReceipeName).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız.!");
            RuleFor(x => x.ReceipeName).MinimumLength(5).WithMessage("Lütfen daha uzun veri girişi yapınız.!");

        }
    }
}
