namespace MemoryCache.Labs.Infrastructure.Exceptions;

public class RecordAlreadyExistsException : Exception
{
    public RecordAlreadyExistsException() : base(ErrorMessagesConstants.RECORD_ALREADY_EXISTS_MESSAGE)
    {
    }
}
