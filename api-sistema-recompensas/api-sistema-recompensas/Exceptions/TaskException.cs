namespace api_sistema_recompensas.Exceptions;

public class TaskException : Exception
{
    public TaskException(string message) : base(message)
    {
    }

    public TaskException(string message, Exception exception) : base(message, exception)
    {
    }
}
