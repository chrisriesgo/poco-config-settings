using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class DependencyInjection
    {
        private IDemoSettings _demoSettings;

        public DependencyInjection(IDemoSettings demoSettings)
        {
            _demoSettings = demoSettings;
        }

        public void ShowConfigValues()
        {
            Console.WriteLine("Connecting to \"{0}\" on port \"{1}\"", _demoSettings.AppName, _demoSettings.AppId.ToString());
            Console.WriteLine();

            if (_demoSettings.GrantAccess)
                Console.WriteLine("You have access!");
            else
                Console.WriteLine("You do not have access :(");
        }
    }
}
