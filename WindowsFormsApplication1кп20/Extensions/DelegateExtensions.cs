using System;

namespace WindowsFormsApplication1кп20.Extensions
{
    public static class DelegateExtensions
    {
        public static void SafeRaise(this Action action)
        {
            var handler = action;
            handler?.Invoke();
        }

        public static void SafeRaise<T>(this Action<T> action, T args)
        {
            var handler = action;
            handler?.Invoke(args);
        }

        public static void SafeRaise(this EventHandler eventHandler, object sender)
        {
            var handler = eventHandler;
            handler?.Invoke(sender, EventArgs.Empty);
        }

        public static void SafeRaise<T>(this EventHandler<T> eventHandler,
            object sender, T args) where T : EventArgs
        {
            var handler = eventHandler;
            handler?.Invoke(sender, args);
        }
    }
}