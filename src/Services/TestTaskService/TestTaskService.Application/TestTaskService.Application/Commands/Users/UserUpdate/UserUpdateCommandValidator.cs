using FluentValidation;
using TestTaskService.Application.Validators;

namespace TestTaskService.Application.Commands.Users.UserUpdate;

public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
{
    public UserUpdateCommandValidator()
    {
        RuleFor(command => command.user)
            .SetValidator(new UserValidator());
    }
}