using FluentValidation;
using UriShortener.Helpers.FluentValidation.ValidationExtension;
using UriShortener.Helpers.Requests;

namespace UriShortener.Helpers.FluentValidation.Validations
{
    public class GetByUrlDtoValidation : AbstractValidator<GetByUrlDto>
    {
        public GetByUrlDtoValidation()
        {
            RuleFor(model=>model.url).ValidateUrl();
        }
    }
}
