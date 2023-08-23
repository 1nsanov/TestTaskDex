using FluentValidation;
using TestTaskService.Application.Dtos.User;

namespace TestTaskService.Application.Commands.Users.UserUpdate;

public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
{
    public UserUpdateCommandValidator()
    {
        RuleFor(command => command.user)
            .SetValidator(new UserValidator());
    }
    
    private class UserValidator : AbstractValidator<UserUpdateDto>
    {
        public UserValidator()
        {
            RuleFor(command => command.Login)
                .NotEmpty().WithMessage("Login is required.")
                .MaximumLength(16).WithMessage("Login cannot exceed 16 characters.");

            RuleFor(command => command.FullName)
                .NotNull().WithMessage("FullName is required.");

            RuleFor(command => command.FullName.Family)
                .NotEmpty().WithMessage("Family name is required.")
                .MaximumLength(50).WithMessage("Family name cannot exceed 50 characters.");

            RuleFor(command => command.FullName.Given)
                .NotEmpty().WithMessage("Given name is required.")
                .MaximumLength(50).WithMessage("Given name cannot exceed 50 characters.");

            RuleFor(command => command.FullName.Middle)
                .MaximumLength(50).WithMessage("Middle name cannot exceed 50 characters.");
        }
    }
}