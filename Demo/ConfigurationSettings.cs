using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ConfigurationSettings<T> : IConfigurationSettings<T> where T : class 
    {
        private readonly Dictionary<string, object> settings;
        private T configuration;

        public ConfigurationSettings()
        {
            Hashtable configSection = null;

            configSection =
                (Hashtable)System.Configuration.ConfigurationManager.GetSection(typeof(T).Name.ToCamelCase());
            if (configSection != null)
            {
                settings = configSection
                    .Cast<DictionaryEntry>()
                    .ToDictionary(kvp => (string)kvp.Key, kvp => (object)kvp.Value);
            }

            HydrateProperties();
        }

        public T Get()
        {
            return configuration;
        }

        private void HydrateProperties()
        {
            // Null Check your settings

            var propertiesMissed = new List<string>();

            configuration = Activator.CreateInstance<T>();

            var props = configuration.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && p.Name != "LockItem")
                .ToList();

            foreach (var prop in props)
            {
                object value = null;
                if (settings.ContainsKey(prop.Name.ToCamelCase()))
                {
                    value = settings[prop.Name.ToCamelCase()];
                }

                if (value != null)
                    prop.SetValue(configuration, Convert.ChangeType(value, prop.PropertyType), null);
                else
                {
                    if (prop.GetCustomAttributes(typeof(OptionalAttribute), false).Length == 0)
                        propertiesMissed.Add(prop.Name);
                }
            }

            if (!propertiesMissed.Any()) return;
            var message =
                String.Format(
                    "{0} is missing the following required properties in configuration: [{1}]. Mark properties as [Optional] if they are not required.",
                    configuration.GetType().Name, String.Join(",", propertiesMissed));
            throw new Exception(message);

        }
    }
}
