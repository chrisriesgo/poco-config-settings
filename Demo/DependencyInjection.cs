using System;

namespace Demo
{
    public class DependencyInjection
    {
        private readonly DemoSettings _demoSettings;

        public DependencyInjection(IConfigurationSettings<DemoSettings> demoSettings)
        {
            _demoSettings = demoSettings.Get();
        }

        public void ShowConfigValues()
        {
            Console.WriteLine("Connecting to \"{0}\" ({1})", _demoSettings.AppName, _demoSettings.AppId.ToString());
            Console.WriteLine();

            Console.WriteLine(_demoSettings.GrantAccess ? "You have access!" : "You do not have access :(");
        }
    }
}
