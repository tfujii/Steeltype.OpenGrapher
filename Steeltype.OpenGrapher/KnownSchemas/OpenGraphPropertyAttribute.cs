namespace Steeltype.OpenGrapher.KnownSchemas
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class OpenGraphPropertyAttribute : Attribute
    {
        public string OpenGraphKey { get; private set; }

        public OpenGraphPropertyAttribute(string key)
        {
            this.OpenGraphKey = key;
        }
    }
}
