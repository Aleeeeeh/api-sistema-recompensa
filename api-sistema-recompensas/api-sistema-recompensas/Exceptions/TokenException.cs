namespace api_sistema_recompensas.Exceptions;

public class TokenException : Exception
{
    public TokenException(string message) : base(message)
    {
    }

    public TokenException(string message, Exception exception) : base(message, exception)
    {
    }
}
