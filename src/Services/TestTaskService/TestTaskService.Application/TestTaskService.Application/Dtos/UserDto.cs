namespace TestTaskService.Application.Dtos;

public record UserDto(
    Guid Id,
    string Login,
    FullNameDto FullName,
    bool IsAdmin
);