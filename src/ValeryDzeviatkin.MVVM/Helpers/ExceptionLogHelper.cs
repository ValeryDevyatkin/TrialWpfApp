using System.Runtime.CompilerServices;

namespace ValeryDzeviatkin.MVVM.Helpers;

public class ExceptionLogItem
{
    public ExceptionLogItem(string source, string message)
    {
        Source = source;
        Message = message;
    }

    public string Source { get; }
    public string Message { get; }
}

public static class ExceptionLogHelper
{
    private static Action<ExceptionLogItem>? _handleExceptionExternal;

    public static void Init(Action<ExceptionLogItem> handleExceptionExternal)
    {
        _handleExceptionExternal = handleExceptionExternal ??
                                   throw new ArgumentNullException(nameof(handleExceptionExternal));
    }

    public static void HandleException(this object sourceObject,
        Exception exception,
        [CallerMemberName] string? sourceMethod = null)
    {
        if (sourceObject == null)
        {
            throw new ArgumentNullException(nameof(sourceObject));
        }

        if (exception == null)
        {
            throw new ArgumentNullException(nameof(exception));
        }

        if (string.IsNullOrWhiteSpace(sourceMethod))
        {
            throw new ArgumentException(nameof(sourceMethod));
        }

        var exceptionSource = $"{sourceObject.GetType().Name}.{sourceMethod}";
        var exceptionMessage = exception.Message;

        _handleExceptionExternal?.Invoke(new ExceptionLogItem(exceptionSource, exceptionMessage));
    }
}