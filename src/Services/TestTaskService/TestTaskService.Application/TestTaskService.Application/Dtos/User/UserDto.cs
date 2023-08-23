namespace TestTaskService.Application.Dtos.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public FullNameDto FullName { get; set; }
    public bool IsAdmin { get; set; }
}