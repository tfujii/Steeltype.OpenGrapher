namespace Steeltype.OpenGrapher
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Steeltype.OpenGrapher.KnownSchemas;

    public partial class OpenGraphSite
    {
        public string Title { get; private set; }

        public ILookup<string, string>? OpenGraph { get; private set; }
        public ILookup<string, string>? MetaTags { get; private set; }

        public OpenGraphSite(ILookup<string, string>? openGraphValues, ILookup<string, string>? metaTagValues, string title)
        {
            this.OpenGraph = openGraphValues;
            this.MetaTags = metaTagValues;
            this.Title = title;
        }

        public Dictionary<string, string[]> OpenGraphToDictionary()
        {
            return this.OpenGraph.ToDictionary(x => x.Key, x => x.ToArray());
        }

        public Dictionary<string, string[]> MetaTagsToDictionary()
        {
            return this.OpenGraph.ToDictionary(x => x.Key, x => x.ToArray());
        }

        public T Extract<T>()
            where T : IKnownSchema, new()
        {
            if (this.OpenGraph == null) return default;

            var schema = new T();

            foreach (var property in typeof(T).GetProperties())
            {
                var openGraphPropertyMetadata = (OpenGraphPropertyAttribute?)Attribute.GetCustomAttribute(property, typeof(OpenGraphPropertyAttribute));
                if (openGraphPropertyMetadata == null) continue;

                var openGraphKeyName = openGraphPropertyMetadata.OpenGraphKey;
                var openGraphKeyValue = this.OpenGraph[openGraphKeyName];

                // Always use the last OpenGraph entry if only one can be used
                // This matches the apparent behavior of the major scrapers
                var scalarRepresentation = openGraphKeyValue?.LastOrDefault();

                // Check for OpenGraph allowed scalar types
                if (property.PropertyType == typeof(bool?))
                {
                    if (scalarRepresentation != null) property.SetValue(schema, bool.Parse(scalarRepresentation));
                }
                else if (property.PropertyType == typeof(DateTime?))
                {
                    if (scalarRepresentation != null) property.SetValue(schema, DateTime.Parse(scalarRepresentation));
                }
                else if (property.PropertyType == typeof(float?))
                {
                    if (scalarRepresentation != null) property.SetValue(schema, float.Parse(scalarRepresentation));
                }
                else if (property.PropertyType == typeof(int?))
                {
                    if (scalarRepresentation != null) property.SetValue(schema, int.Parse(scalarRepresentation));
                }
                else if (property.PropertyType == typeof(string))
                {
                    // NOTE: This covers "Enum", "String", and "URL"
                    property.SetValue(schema, scalarRepresentation);
                }
                else if (property.PropertyType == typeof(string[]))
                {
                    // NOTE: This covers basic String arrays
                    property.SetValue(schema, openGraphKeyValue?.ToArray());
                }
                else
                {
                    // We weren't able to find a matching type
                    Debug.Write("Unable to parse to ", property.PropertyType.ToString());
                    throw new InvalidCastException("Unable to parse schema attribute.");
                }
            }

            return schema;
        }
    }
}
