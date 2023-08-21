namespace TestTaskService.Application.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public FullNameDto FullName { get; set; }
    public bool IsAdmin { get; set; }
}