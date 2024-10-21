using DTO.DTOS.ContactUsDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.ValidationRule.ContactUsValidator
{
    public class NewContactUsValidator:AbstractValidator<NewContactUsDTO>
    {
        public NewContactUsValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Elektron ünvan boş ola bilməz!");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Sizə müraciət  etməyimiz üçün adınızı və soyadınızı daxil edin!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş ola bilməz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mesaj mətinini daxil edin!");


        }
    }
}
