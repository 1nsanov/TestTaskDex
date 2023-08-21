namespace TestTaskService.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Guid id)
        : base($"Entity with id {id} not found")
    {
    }
    
    public EntityNotFoundException(string message) : base(message)
    {
    }

    public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}