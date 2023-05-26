using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz!!");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("Kullanıcı adı 2 karakterden küçük olamaz!!");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Kullanıcı soyadı boş bırakılmaz!!");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Kullanıcı soyadı 2 karakterden küçük olamaz!!");
            //RuleFor(u => u.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz!!");
            //RuleFor(u => u.Password).Must(PasswordLength).WithMessage("Şifre 8 Karakterli Olmalıdır.");
          
        }

        private bool PasswordLength(int arg)
        {
            return arg.ToString().Length > 8;
        }
    }
}
