using System;
using System.Reflection;
using ForeignLibrary;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var foreignFooService = new ForeignService();
            var fooService = DispatchProxy.Create<IFooService, LoggerProxy>();
            (fooService as LoggerProxy).SetRemoteObject(foreignFooService);

            Console.WriteLine($"{fooService.Foo()}");
            Console.Read();
        }
    }
}
