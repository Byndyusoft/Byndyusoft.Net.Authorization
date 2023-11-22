namespace Byndyusoft.Net.YandexAuth.Internals.Extensions;

using System;
using System.Linq;
using Byndyusoft.ModelResult;
using FluentValidation;

internal static class FluentValidatorExtensions
{
    public static ErrorInfoItem[] ValidateAndGetErrorInfoItems<TValidator, TDto>(
        this TValidator validator,
        TDto dto)
        where TValidator : AbstractValidator<TDto>
    {
        var validationResult = validator.Validate(dto);
        if (validationResult.IsValid)
            return Array.Empty<ErrorInfoItem>();

        var items = validationResult.Errors.Select(i => new ErrorInfoItem(i.PropertyName, i.ErrorMessage)).ToArray();
        return items;
    }
}