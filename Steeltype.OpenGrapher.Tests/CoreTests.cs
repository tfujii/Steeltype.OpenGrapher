using NUnit.Framework;
using Steeltype.OpenGrapher.KnownSchemas;
using System.Linq;
using System.Threading.Tasks;

namespace Steeltype.OpenGrapher.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Setup code here if needed
        }

        [Test]
        public async Task ShouldParseMetaTagsFromHTMLAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.That(site.OpenGraph.Count, Is.Not.Zero);
            Assert.That(site.MetaTags.Count, Is.Not.Zero);
        }

        [Test]
        public async Task ShouldParseBasicOpenGraphMetadataAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.That(site.OpenGraph["og:title"].Single(), Is.EqualTo("Open Graph protocol"));
            Assert.That(site.OpenGraph["og:type"].Single(), Is.EqualTo("website"));
            Assert.That(site.OpenGraph["og:image"].Single(), Is.EqualTo("https://ogp.me/logo.png"));
            Assert.That(site.OpenGraph["og:url"].Single(), Is.EqualTo("https://ogp.me/"));
        }

        [Test]
        public async Task ShouldParseBasicMetadataAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.That(site.Title, Is.EqualTo("The Open Graph protocol"));
            Assert.That(site.MetaTags["description"].Single(), Is.EqualTo("The Open Graph protocol enables any web page to become a rich object in a social graph."));
            Assert.That(site.MetaTags["robots"].Single(), Is.EqualTo("index,follow,noodp,noydir"));
            Assert.That(site.MetaTags["viewport"].Single(), Is.EqualTo("width=device-width,initial-scale=1,user-scalable=yes"));
        }

        [Test]
        public async Task CanExtractOpenGraphBasicSchemaAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            var schema = site.Extract<BasicSchema>();

            Assert.That(schema.Title, Is.EqualTo("Open Graph protocol"));
            Assert.That(schema.Type, Is.EqualTo("website"));
            Assert.That(schema.Image, Is.EqualTo("https://ogp.me/logo.png"));
            Assert.That(schema.Url, Is.EqualTo("https://ogp.me/"));
        }

        [Test]
        public async Task CanExportOpenGraphMetadataAsDictionary()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var openGraphAsDictionary = site.OpenGraphToDictionary();

            Assert.That(openGraphAsDictionary.Count, Is.EqualTo(site.OpenGraph.Count));
        }

        [Test]
        public async Task CanExportMetadataAsDictionary()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var metaTagsAsDictionary = site.MetaTagsToDictionary();

            Assert.That(metaTagsAsDictionary.Count, Is.EqualTo(site.MetaTags.Count));
        }

        [Test]
        public async Task CanExportOpenGraphMetadataAsHTML()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var openGraphAsHTML = site.OpenGraphToHTML();

            Assert.That(
                openGraphAsHTML.Replace(" ", "").Replace("\n", "").Replace("\r", ""),
                Is.EqualTo(TestData.EXPECTED_BASIC_SCHEMA_OPENGRAPH_TAGS.Replace(" ", "").Replace("\n", "").Replace("\r", ""))
            );
        }

        [Test]
        public async Task CanExportMetadataAsHTML()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var metaTagsAsHTML = site.MetaTagsToHTML();

            Assert.That(
                metaTagsAsHTML.Replace(" ", "").Replace("\n", "").Replace("\r", ""),
                Is.EqualTo(TestData.EXPECTED_BASIC_SCHEMA_META_TAGS.Replace(" ", "").Replace("\n", "").Replace("\r", ""))
            );
        }

        [Test]
        public async Task CanCheckForOpenGraphSchemas()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.That(site.HasOpenGraphSchema("og"), Is.True);
            Assert.That(site.HasOpenGraphSchema("og:image"), Is.True);
            Assert.That(site.HasOpenGraphSchema("og:locale:alternate"), Is.True);

            Assert.That(site.HasOpenGraphSchema("invalid"), Is.False);
            Assert.That(site.HasOpenGraphSchema("og:invalid"), Is.False);
            Assert.That(site.HasOpenGraphSchema("og:locale:alternative:"), Is.False);
        }
    }
}