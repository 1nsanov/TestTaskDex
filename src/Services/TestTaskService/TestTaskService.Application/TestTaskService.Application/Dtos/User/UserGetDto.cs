namespace TestTaskService.Application.Dtos.User;

public class UserGetDto
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public FullNameDto FullName { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime CreateDate { get; set; }
}