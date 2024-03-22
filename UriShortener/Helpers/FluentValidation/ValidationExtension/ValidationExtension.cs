using FluentValidation;

namespace UriShortener.Helpers.FluentValidation.ValidationExtension;

public static class ValidationExtension
{
    public static IRuleBuilder<T, string> ValidateUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        var validPattern = @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$";
        return ruleBuilder.Matches(validPattern).WithMessage("Invalid url format").NotNull();
    }
}
