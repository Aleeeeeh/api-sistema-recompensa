namespace api_sistema_recompensas.Exceptions;

public class AccountException : Exception
{
    public AccountException(string message) : base(message)
    {
    }

    public AccountException(string message, Exception exception) : base(message, exception)
    {
    }
}
