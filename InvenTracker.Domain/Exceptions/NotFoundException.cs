namespace InvenTracker.Domain.Exceptions;

public class NotFoundException: DomainException
{
    public NotFoundException(string message) : base(message)
    {
        
    }
}