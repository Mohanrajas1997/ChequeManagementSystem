using System.Configuration;

namespace CheckManagementSystem
{
    public class ConfigHelper : ConfigurationSection
    {
        /// <summary>
        /// The value of the property here "Folders" needs to match that of the config file section
        /// </summary>
        [ConfigurationProperty("FilterKeys")]
        public FilterHashKeyCollection HashKeys
        {
            get { return ((FilterHashKeyCollection)(base["FilterKeys"])); }
        }

        [System.Configuration.ConfigurationProperty("Branch")]
        public FilterHashKeyCollection HashKeys1
        {
            get { return ((FilterHashKeyCollection)(base["Branch"])); }
        }
        [System.Configuration.ConfigurationProperty("Location")]
        public FilterHashKeyCollection HashKeys2
        {
            get { return ((FilterHashKeyCollection)(base["Location"])); }
        }
        [System.Configuration.ConfigurationProperty("Uploadtype")]
        public FilterHashKeyCollection HashKeys3
        {
            get { return ((FilterHashKeyCollection)(base["Uploadtype"])); }
        }
    }

    /// <summary>
    /// The collection class that will store the list of each element/item that
    /// is returned back from the configuration manager.
    /// </summary>
    [ConfigurationCollection(typeof(FilterHashElement))]
    public class FilterHashKeyCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FilterHashElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FilterHashElement)(element)).Key;
        }

        public FilterHashElement this[int idx]
        {
            get
            {
                return (FilterHashElement)BaseGet(idx);
            }
        }
    }

    /// <summary>
    /// The class that holds onto each element returned by the configuration manager.
    /// </summary>
    public class FilterHashElement : ConfigurationElement
    {
        [ConfigurationProperty("key", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Key
        {
            get
            {
                return ((string)(base["key"]));
            }
            set
            {
                base["key"] = value;
            }
        }

        [ConfigurationProperty("value", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Value
        {
            get
            {
                return ((string)(base["value"]));
            }
            set
            {
                base["value"] = value;
            }
        }
        [ConfigurationProperty("code", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Code
        {
            get
            {
                return ((string)(base["code"]));
            }
            set
            {
                base["code"] = value;
            }
        }
       
    }
}
