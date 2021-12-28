namespace Steeltype.OpenGrapher
{
    using HtmlAgilityPack;
    using System.Linq;

    public static class OpenGrapher
    {
        public const string OPEN_GRAPH_PREFIX = "og:";
        public static OpenGraphSite? ParseSite(string htmlContent)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            HtmlNodeCollection metaTags = document.DocumentNode.SelectNodes("//meta");

            if (metaTags == null)
            {
                return null;
            }

            var title = document.DocumentNode.SelectSingleNode("//title")?.InnerText;

            var openGraphValues = metaTags
                .Where(x => x.Attributes.Contains("property"))
                .Where(x => !string.IsNullOrEmpty(x.Attributes["property"].Value))
                .Where(x => x.Attributes["property"].Value.StartsWith(OPEN_GRAPH_PREFIX))
                .ToLookup(x => x.Attributes["property"].Value, x => x.Attributes["content"].Value);

            var metaValues = metaTags
                .Where(x => x.Attributes.Contains("name"))
                .Where(x => !string.IsNullOrEmpty(x.Attributes["name"].Value))
                .ToLookup(x => x.Attributes["name"].Value, x => x.Attributes["content"].Value);

            var openGraphSite = new OpenGraphSite(openGraphValues, metaValues, title);

            return openGraphSite;
        }
    }
}
