using FluentValidation;
using TestTaskService.Application.Validators;

namespace TestTaskService.Application.Commands.Users.UserAdd;

public class UserAddCommandValidator : AbstractValidator<UserAddCommand>
{
    public UserAddCommandValidator()
    {
        RuleFor(command => command.user)
            .SetValidator(new UserValidator());
    }
}