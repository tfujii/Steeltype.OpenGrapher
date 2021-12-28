using NUnit.Framework;
using Steeltype.OpenGrapher.KnownSchemas;
using System.Linq;
using System.Threading.Tasks;

namespace Steeltype.OpenGrapher.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task ShouldParseMetaTagsFromHTMLAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.NotZero(site.OpenGraph.Count);
            Assert.NotZero(site.MetaTags.Count);
        }

        [Test]
        public async Task ShouldParseBasicOpenGraphMetadataAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.AreEqual(site.OpenGraph["og:title"].Single(), @"Open Graph protocol");
            Assert.AreEqual(site.OpenGraph["og:type"].Single(), @"website");
            Assert.AreEqual(site.OpenGraph["og:image"].Single(), @"https://ogp.me/logo.png");
            Assert.AreEqual(site.OpenGraph["og:url"].Single(), @"https://ogp.me/");
        }

        [Test]
        public async Task ShouldParseBasicMetadataAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.AreEqual(site.Title, @"The Open Graph protocol");
            Assert.AreEqual(site.MetaTags["description"].Single(), @"The Open Graph protocol enables any web page to become a rich object in a social graph.");
            Assert.AreEqual(site.MetaTags["robots"].Single(), @"index,follow,noodp,noydir");
            Assert.AreEqual(site.MetaTags["viewport"].Single(), @"width=device-width,initial-scale=1,user-scalable=yes");
        }

        [Test]
        public async Task CanExtractOpenGraphBasicSchemaAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            var schema = site.Extract<BasicSchema>();

            Assert.AreEqual(@"Open Graph protocol", schema.Title);
            Assert.AreEqual(@"website", schema.Type);
            Assert.AreEqual(@"https://ogp.me/logo.png", schema.Image);
            Assert.AreEqual(@"https://ogp.me/", schema.Url);
        }

        [Test]
        public async Task CanExportOpenGraphMetadataAsDictionary()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var openGraphAsDictionary = site.OpenGraphToDictionary();

            Assert.AreEqual(site.OpenGraph.Count, openGraphAsDictionary.Count);
        }

        [Test]
        public async Task CanExportMetadataAsDictionary()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var openGraphAsDictionary = site.MetaTagsToDictionary();

            Assert.AreEqual(site.MetaTags.Count, openGraphAsDictionary.Count);
        }

        [Test]
        public async Task CanExportOpenGraphMetadataAsHTML()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var openGraphAsHTML = site.OpenGraphToHTML();

            Assert.AreEqual(
                TestData.EXPECTED_BASIC_SCHEMA_OPENGRAPH_TAGS.Replace(" ", "").Replace("\n", "").Replace("\r", ""),
                openGraphAsHTML.Replace(" ", "").Replace("\n", "").Replace("\r", "")
            );
        }

        [Test]
        public async Task CanExportMetadataAsHTML()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);
            var metaTagsAsHTML = site.MetaTagsToHTML();

            Assert.AreEqual(
                TestData.EXPECTED_BASIC_SCHEMA_META_TAGS.Replace(" ", "").Replace("\n", "").Replace("\r", ""), 
                metaTagsAsHTML.Replace(" ", "").Replace("\n", "").Replace("\r", "")
            );
        }
    }
}