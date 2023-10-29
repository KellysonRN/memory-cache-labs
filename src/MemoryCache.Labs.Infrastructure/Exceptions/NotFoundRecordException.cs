namespace MemoryCache.Labs.Infrastructure.Exceptions;

public class NotFoundRecordException : Exception
{
    public NotFoundRecordException() : base(ErrorMessagesConstants.RECORD_NOT_FOUND_MESSAGE)
    {
        
    }
}
