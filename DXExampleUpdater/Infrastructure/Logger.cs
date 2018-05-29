using System;
using System.Linq;

namespace DXExampleUpdater
{
    public static class Logger
    {
        public static Action<string> LogAction { get; set; }
        public static void Log(string text)
        {
            Console.WriteLine(text);
            LogAction?.Invoke(text + Environment.NewLine);
        }

        public static void RegisterLogAction(Action<string> action)
        {
            LogAction = action;
        }
    }

}
