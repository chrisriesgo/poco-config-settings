using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Initializing IoC...");
            Console.WriteLine();

            var container = new WindsorContainer();

            container.Register(Component.For(typeof(DependencyInjection)));

            container.Register(
                Component.For(typeof(IDemoSettings))
                    .ImplementedBy(typeof(DemoSettings))
                    .Named("demoSettings"));
            
            var di = container.Resolve<DependencyInjection>();
            di.ShowConfigValues();

            Console.ReadKey();
        }
    }
}
