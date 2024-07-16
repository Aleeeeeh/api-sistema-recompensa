namespace api_sistema_recompensas.Exceptions;

public class UserException(string message, Exception exception) : Exception(message, exception)
{
}
