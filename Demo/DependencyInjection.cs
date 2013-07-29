using System;

namespace Demo
{
    public class DependencyInjection
    {
        private readonly IDemoSettings _demoSettings;

        public DependencyInjection(IDemoSettings demoSettings)
        {
            _demoSettings = demoSettings;
        }

        public void ShowConfigValues()
        {
            Console.WriteLine("Connecting to \"{0}\" ({1})", _demoSettings.AppName, _demoSettings.AppId.ToString());
            Console.WriteLine();

            Console.WriteLine(_demoSettings.GrantAccess ? "You have access!" : "You do not have access :(");
        }
    }
}
