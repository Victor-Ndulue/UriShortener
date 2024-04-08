using FluentValidation;
using UriShortener.Helpers.FluentValidation.ValidationExtension;
using UriShortener.Helpers.Requests;

namespace UriShortener.Helpers.FluentValidation.Validations;

public class AddUrlDtoValidation : AbstractValidator<AddUriDto>
{
    public AddUrlDtoValidation()
    {
        RuleFor(model => model.mainUrl).ValidateUrl();
        RuleFor(model => model.preferredPath).NotNull();
    }
}
