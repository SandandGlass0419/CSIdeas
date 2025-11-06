using System;
using System.Linq;

namespace GenericErrorTest;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("main start");
        EnvironmentError.HookEvent();

        GenericClass.Function();
    }
}

public class EnvironmentError : IEnvironmentErrorHandler
{
    public static void HookEvent()
    {
        ErrorThrower.ErrorEvent += OnError;
    }

    public static void OnError(object sender, ErrorEventArgs e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("exited");
    }
}