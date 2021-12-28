using NUnit.Framework;
using Steeltype.OpenGrapher.KnownSchemas;
using System.Linq;

namespace Steeltype.OpenGrapher.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ShouldParseMetaTagsFromHTML()
        {
            var site = OpenGrapher.ParseSite(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.NotZero(site.OpenGraph.Count);
            Assert.NotZero(site.MetaTags.Count);
        }

        [Test]
        public void ShouldParseBasicOpenGraphMetadata()
        {
            var site = OpenGrapher.ParseSite(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.AreEqual(site.OpenGraph["og:title"].Single(), @"Open Graph protocol");
            Assert.AreEqual(site.OpenGraph["og:type"].Single(), @"website");
            Assert.AreEqual(site.OpenGraph["og:image"].Single(), @"https://ogp.me/logo.png");
            Assert.AreEqual(site.OpenGraph["og:url"].Single(), @"https://ogp.me/");
        }

        [Test]
        public void ShouldParseBasicMetadata()
        {
            var site = OpenGrapher.ParseSite(TestData.VALID_HTML_BASIC_SCHEMA);

            Assert.AreEqual(site.Title, @"The Open Graph protocol");
            Assert.AreEqual(site.MetaTags["description"].Single(), @"The Open Graph protocol enables any web page to become a rich object in a social graph.");
            Assert.AreEqual(site.MetaTags["robots"].Single(), @"index,follow,noodp,noydir");
            Assert.AreEqual(site.MetaTags["viewport"].Single(), @"width=device-width,initial-scale=1,user-scalable=yes");
        }

        [Test]
        public void CanExtractOpenGraphBasicSchema()
        {
            var site = OpenGrapher.ParseSite(TestData.VALID_HTML_BASIC_SCHEMA);

            var schema = site.Extract<BasicSchema>();

            Assert.AreEqual(schema.Title, @"Open Graph protocol");
            Assert.AreEqual(schema.Type, @"website");
            Assert.AreEqual(schema.Image, @"https://ogp.me/logo.png");
            Assert.AreEqual(schema.Url, @"https://ogp.me/");
        }
    }
}