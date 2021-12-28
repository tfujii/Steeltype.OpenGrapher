namespace Steeltype.OpenGrapher
{
    using System.Linq;
    using System.Threading.Tasks;
    using AngleSharp;
    using AngleSharp.Dom;

    /// <summary>
    /// Used to parse OpenGraph-enabled sites.
    /// </summary>
    public static class OpenGrapher
    {
        /// <summary>
        /// The OpenGraph prefix.
        /// </summary>
        public const string OPEN_GRAPH_PREFIX = "og:";

        /// <summary>
        /// Loads the specified HTML content.
        /// </summary>
        /// <param name="htmlContent">HTML Content as a string.</param>
        /// <returns>The object representation of the site.</returns>
        public static async Task<OpenGraphSite?> LoadAsync(string htmlContent)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(htmlContent));

            return Load(document);
        }

        /// <summary>
        /// Loads the specified AngleSharp document.
        /// </summary>
        /// <param name="document">An HTMLAgilityPack document.</param>
        /// <returns>The object representation of the site.</returns>
        public static OpenGraphSite? Load(IDocument document)
        {
            var metaTags = document.QuerySelectorAll("meta");

            if (metaTags == null)
            {
                return null;
            }

            var title = document.QuerySelector("title")?.TextContent;

            var openGraphValues = metaTags
                .Where(x => x.Attributes != null && x.Attributes["property"] != null)
                .Where(x => !string.IsNullOrEmpty(x.Attributes["property"]?.Value))
                .Where(x => x.Attributes["property"]?.Value.StartsWith(OPEN_GRAPH_PREFIX) ?? false)
                .ToLookup(x => x.Attributes["property"]?.Value, x => x.Attributes["content"]?.Value);

            var metaValues = metaTags
                .Where(x => x.Attributes != null && x.Attributes["name"] != null)
                .Where(x => !string.IsNullOrEmpty(x.Attributes["name"]?.Value))
                .ToLookup(x => x.Attributes["name"]?.Value, x => x.Attributes["content"]?.Value);

            var openGraphSite = new OpenGraphSite(openGraphValues, metaValues, title);

            return openGraphSite;
        }
    }
}
