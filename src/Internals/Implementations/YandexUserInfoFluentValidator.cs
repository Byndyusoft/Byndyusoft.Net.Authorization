namespace Byndyusoft.Net.YandexAuth.Internals.Implementations;

using Dtos;
using FluentValidation;

internal class YandexUserInfoFluentValidator : AbstractValidator<YandexUserInfoDto>
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