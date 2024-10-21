using FluentValidation;
using UI.Areas.GoldManagementPanel.DTOS.ProductDTO;

namespace UI.Areas.GoldManagementPanel.ValidationRule.ProductValidator
{
    public class NewProductValidator:AbstractValidator<NewProductDTO>
    {
        public NewProductValidator(NewProductDTO dto)
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Qiyməti daxil edin!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş ola bilməz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kateqoriya seçimi edin!");
            RuleFor(x => x.ProductImages)
                .NotEmpty().WithMessage("Ən az 2 rəsim seçilməlidir!")
                .Must(images => images != null && images.Length >= 2 && images.Length <= 7)
                .WithMessage("Minimum 2 və maksimum 7 rəsim seçilməlidir!")
                .Must(images => AreAllImagesValid(dto))
                .WithMessage("Yalnız şəkil tipli fayllar qəbul edilir!")
                .Must(images => images != null && images.All(image => image.Length <= 4 * 1024 * 1024))
                .WithMessage("Hər rəsim faylının ölçüsü 4 MB-dan çox olmamalıdır!");

            if (dto.IsSale)
            {
                RuleFor(x => x.LastDateForIsSale).NotEmpty().WithMessage("Endirim üçün sonuncu günü daxil edin!");
                RuleFor(x => x.SalesPrice).NotEmpty().WithMessage("Endirim qiymətini daxil edin!");
            }
        }

        private bool AreAllImagesValid(NewProductDTO dto)
        {
            if (dto.ProductImages == null) return false;
            var imageTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/bmp" };
            return dto.ProductImages.All(file => imageTypes.Contains(file.ContentType));
        }






    }
}
