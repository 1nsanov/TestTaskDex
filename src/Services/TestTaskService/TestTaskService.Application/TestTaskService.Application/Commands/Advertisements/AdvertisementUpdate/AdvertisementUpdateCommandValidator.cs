﻿using FluentValidation;
using TestTaskService.Application.Dtos.Advertisement;

namespace TestTaskService.Application.Commands.Advertisements.AdvertisementUpdate;

public class AdvertisementUpdateCommandValidator : AbstractValidator<AdvertisementUpdateCommand>
{
    public AdvertisementUpdateCommandValidator()
    {
        RuleFor(command => command.advertisement)
            .SetValidator(new AdvertisementValidator());
    }
    
    private class AdvertisementValidator : AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
        
            RuleFor(a => a.Text)
                .NotEmpty().WithMessage("Text is required.")
                .MaximumLength(500).WithMessage("Text cannot exceed 500 characters.");

            RuleFor(a => a.Rate)
                .GreaterThanOrEqualTo(0).WithMessage("Rate cannot less 0")
                .LessThanOrEqualTo(10).WithMessage("Rate cannot greater 10");

            RuleFor(a => a.ExpireDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot less date now");
            
            RuleFor(a => a.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl cannot be empty")
                .Matches(@"^https://firebasestorage\.googleapis\.com/v0/b/[^/]+/o/[^/]+(\?.*)?$").WithMessage("ImageUrl must be a valid Firebase Storage URL")
                .Unless(a => a.ImageUrl is null);
        }
    }
}