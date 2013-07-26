using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Initializing IoC...");
            Console.WriteLine();

            var container = new WindsorContainer();

            //container.AddComponent("dependencyInjection", typeof(DependencyInjection));
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
