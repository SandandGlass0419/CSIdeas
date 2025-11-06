using System;
using System.Linq;
using System.Collections.Generic;
using GenericErrorTest;

namespace GenericErrorTest;

public class GenericClass
{
    public static void Function()
    {
        Console.WriteLine("function executed");

        ErrorThrower.Throw("error", 123);
    }
}

public class ErrorEventArgs : EventArgs
{
    public string Message { get; }
    public int ErrorCode { get; } = 1;

    public ErrorEventArgs(string message, int errorCode)
    {
        this.Message = message;
        this.ErrorCode = errorCode;
    }

    public ErrorEventArgs(string message)
    {
        this.Message = message;
    }
}


public class ErrorThrower
{
    public static event EventHandler<ErrorEventArgs> ErrorEvent;

    public static void Throw(string message, int errorCode)
    {
        ErrorEvent?.Invoke(null, new ErrorEventArgs(message, errorCode));
    }

    public static void Throw(string message)
    {
        ErrorEvent?.Invoke(null, new ErrorEventArgs(message));
    }
}

public interface IEnvironmentErrorHandler
{
    public static abstract void HookEvent();
    public static abstract void OnError(object sender, ErrorEventArgs e);
}
