namespace api_sistema_recompensas.Exceptions;

public class UserException : Exception
{
    public UserException(string message) : base(message)
    {
    }

    public UserException(string message, Exception exception) : base(message, exception)
    {
    }
}
