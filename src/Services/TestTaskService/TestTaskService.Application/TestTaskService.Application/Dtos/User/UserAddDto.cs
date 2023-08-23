namespace TestTaskService.Application.Dtos.User;

public class UserAddDto
{
    public string Login { get; set; }
    public FullNameDto FullName { get; set; }
    public bool IsAdmin { get; set; }
}