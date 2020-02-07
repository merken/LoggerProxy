using System;
using System.Reflection;

namespace MyApp
{
    public class LoggerProxy : DispatchProxy
    {
        private object remote;
        public LoggerProxy SetRemoteObject(object remote)
        {
            this.remote = remote;
            return this;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var originalConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Calling method {targetMethod.Name} on {this.remote}");
            var methodOnRemote = this.remote.GetType().GetMethod(targetMethod.Name);
            var remoteResult = methodOnRemote.Invoke(this.remote, args);
            Console.WriteLine($"Called method {targetMethod.Name} on {this.remote} and result was {remoteResult}");
            
            Console.ForegroundColor = originalConsoleColor;
            return remoteResult;
        }
    }
}