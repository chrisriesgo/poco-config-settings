namespace Demo
{
    public class DemoSettings
    {
        /// All properties are implicitly required.
        /// Applying the Optional attribute flags a property as not being required.
        
        public string AppName { get; set; }
        public int AppId { get; set; }
        public bool GrantAccess { get; set; }
        
        /// <summary>
        /// There is a config settings entry for this property. The value is populated even when marked as Optional.
        /// </summary>
        [Optional]
        public string OptionalSetting { get; set; }

        /// <summary>
        /// There is no config settings entry for this property. The value will be Null.
        /// </summary>
        [Optional]
        public string NoSettingEntry { get; set; }
    }
}
