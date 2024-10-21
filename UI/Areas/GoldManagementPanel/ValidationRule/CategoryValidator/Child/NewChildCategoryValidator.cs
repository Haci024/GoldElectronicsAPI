using FluentValidation;
using UI.Areas.GoldManagementPanel.DTOS.CategoryDTO.Child;

namespace UI.Areas.GoldManagementPanel.ValidationRule.CategoryValidator.Child
{
    public class NewChildCategoryValidator:AbstractValidator<NewChildCategoryDTO>
    {
        public NewChildCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Zəhmət olmasa adı daxil edin!");
            RuleFor(x => x.MainCategoryId).NotEmpty().WithMessage("Zəhmət olmasa əsas kateqoriyanı seçin!");
        }
    }
}
