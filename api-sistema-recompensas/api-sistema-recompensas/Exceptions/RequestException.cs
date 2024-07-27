namespace api_sistema_recompensas.Exceptions;

public class RequestException : Exception
{
    public RequestException(string message) : base(message)
    {
    }

    public RequestException(string message, Exception exception) : base(message, exception)
    {
    }
}
