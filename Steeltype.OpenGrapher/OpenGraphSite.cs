namespace Steeltype.OpenGrapher
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Steeltype.OpenGrapher.KnownSchemas;

    /// <summary>
    /// Represents OpenGraph metadata extracted from a site.
    /// </summary>
    public partial class OpenGraphSite
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphSite"/> class (NOT INTENDED FOR DIRECT USE).
        /// </summary>
        /// <param name="openGraphValues">The OpenGraph values.</param>
        /// <param name="metaTagValues">The meta tag values.</param>
        /// <param name="title">The site title.</param>
        public OpenGraphSite(ILookup<string, string>? openGraphValues, ILookup<string, string>? metaTagValues, string? title)
        {
            this.OpenGraph = openGraphValues;
            this.MetaTags = metaTagValues;
            this.Title = title;
        }

        /// <summary>
        /// Gets the title of the loaded site.
        /// </summary>
        /// <value>
        /// The site title.
        /// </value>
        public string? Title { get; private set; }

        /// <summary>
        /// Gets the raw OpenGraph entries for the site.
        /// </summary>
        /// <value>
        /// The OpenGraph entries.
        /// </value>
        public ILookup<string, string>? OpenGraph { get; private set; }

        /// <summary>
        /// Gets the raw meta tag entries for the site.
        /// </summary>
        /// <value>
        /// The meta tag entries.
        /// </value>
        public ILookup<string, string>? MetaTags { get; private set; }

        /// <summary>
        /// Exports the OpenGraph values to a dictionary.
        /// </summary>
        /// <returns>A dictionary of OpenGraph values.</returns>
        public Dictionary<string, string[]> OpenGraphToDictionary()
        {
            return this.OpenGraph.ToDictionary(x => x.Key, x => x.ToArray());
        }

        /// <summary>
        /// Exports the (non-OpenGraph) Meta tag values to a dictionary.
        /// </summary>
        /// <returns>A dictionary of Meta tag values.</returns>
        public Dictionary<string, string[]> MetaTagsToDictionary()
        {
            return this.OpenGraph.ToDictionary(x => x.Key, x => x.ToArray());
        }

        /// <summary>
        /// Extracts known OpenGraph schemas to strongly-typed objects.
        /// </summary>
        /// <typeparam name="T">A known OpenGraph schema type.</typeparam>
        /// <returns>OpenGraph schema object.</returns>
        /// <exception cref="System.InvalidCastException">Unable to parse schema attribute.</exception>
        public T Extract<T>()
            where T : IKnownSchema, new()
        {
#pragma warning disable CS8603 // Possible null reference return. Not fixed for .NETStandard2.1 compatibility.
            if (this.OpenGraph == null) return default;
#pragma warning restore CS8603 // Possible null reference return. Not fixed for .NETStandard2.1 compatibility.

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
