using System.Globalization;

namespace TicketingSystem.Domain.Exceptions;

public class TicketingSystemException : Exception
{
    public TicketingSystemException()
        : base()
    {
    }


    public TicketingSystemException(string message)
        : base(message)
    {
    }

    public TicketingSystemException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
