namespace AuthorizationPackage.Internals;

using FluentValidation;

internal class YandexUserInfoFluentValidator : AbstractValidator<UserInfoDto>
{
    public YandexUserInfoFluentValidator()
    {
        RuleFor(i => i.Login).NotEmpty();
        RuleFor(i => i.FirstName).NotEmpty();
        RuleFor(i => i.LastName).NotEmpty();
        RuleFor(i => i.Id).NotEmpty();
        RuleFor(i => i.DefaultAvatarId).NotEmpty();
    }
}