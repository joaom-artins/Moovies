﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Movies.Common.Notification;

namespace Moovies.Utils.Filters;
public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var validationErrors = new List<ValidationFailure>();

        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument is null)
            {
                continue;
            }

            if (argument is IEnumerable enumerableArgument && argument is not string)
            {
                var index = 0;
                bool isEmpty = true;
                foreach (var item in enumerableArgument)
                {
                    isEmpty = false;
                    if (item == null)
                    {
                        continue;
                    }

                    var validator = GetValidatorForArgument(context, item);
                    if (validator != null)
                    {
                        var validationResult = await validator.ValidateAsync(new ValidationContext<object>(item));
                        if (!validationResult.IsValid)
                        {
                            foreach (var error in validationResult.Errors)
                            {
                                error.PropertyName = $"{error.PropertyName}[{index}]";
                                validationErrors.Add(error);
                            }
                        }
                    }
                    index++;
                }

                if (isEmpty)
                {
                    validationErrors.Add(new ValidationFailure("", Messages.Common.RequestListRequired));
                }
            }
            else
            {
                var validator = GetValidatorForArgument(context, argument);
                if (validator is not null)
                {
                    var validationResult = await validator.ValidateAsync(new ValidationContext<object>(argument));
                    if (!validationResult.IsValid)
                    {
                        validationErrors.AddRange(validationResult.Errors);
                    }
                }
            }
        }

        if (validationErrors.Count != 0)
        {
            var path = context.HttpContext.Request.Path;
            var result = new ValidationProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Title = Titles.InvalidRequisition,
                Detail = Messages.Common.ValidationError,
                Instance = path,
                Extensions = { { "traceId", Activity.Current?.Id } }
            };

            foreach (var failure in validationErrors)
            {
                if (result.Errors.TryGetValue(failure.PropertyName, out string[]? value))
                {
                    result.Errors[failure.PropertyName] = value.Concat([failure.ErrorMessage]).ToArray();
                }
                else
                {
                    result.Errors.Add(failure.PropertyName, [failure.ErrorMessage]);
                }
            }

            context.Result = new BadRequestObjectResult(result);
            return;
        }
        await next();
    }

    private static IValidator? GetValidatorForArgument(ActionExecutingContext context, object argument)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
        return (IValidator?)context.HttpContext.RequestServices.GetService(validatorType);
    }
}

