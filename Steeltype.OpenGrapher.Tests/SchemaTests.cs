using NUnit.Framework;
using Steeltype.OpenGrapher.KnownSchemas;

namespace Steeltype.OpenGrapher.Tests
{
    public class SchemaTests
    {
        [Test]
        public void CanExtractOpenGraphImageSchema()
        {
            var site = OpenGrapher.Load(TestData.VALID_HTML_IMAGE_SCHEMA);

            var schema = site.Extract<ImageSchema>();

            Assert.AreEqual(schema.Image, @"https://example.com/ogp.jpg");
            Assert.AreEqual(schema.SecureUrl, @"https://secure.example.com/ogp.jpg");
            Assert.AreEqual(schema.MimeType, @"image/jpeg");
            Assert.AreEqual(schema.Width, 400);
            Assert.AreEqual(schema.Height, 300);
            Assert.AreEqual(schema.ImageAlt, @"A shiny red apple with a bite taken out");
        }

        [Test]
        public void CanExtractOpenGraphVideoSchema()
        {
            var site = OpenGrapher.Load(TestData.VALID_HTML_VIDEO_SCHEMA);

            var schema = site.Extract<VideoSchema>();

            Assert.AreEqual(schema.Video, @"https://example.com/movie.swf");
            Assert.AreEqual(schema.SecureUrl, @"https://secure.example.com/movie.swf");
            Assert.AreEqual(schema.MimeType, @"application/x-shockwave-flash");
            Assert.AreEqual(schema.Width, 400);
            Assert.AreEqual(schema.Height, 300);
            Assert.AreEqual(schema.VideoAlt, null);
        }

        [Test]
        public void CanExtractOpenGraphAudioSchema()
        {
            var site = OpenGrapher.Load(TestData.VALID_HTML_AUDIO_SCHEMA);

            var schema = site.Extract<AudioSchema>();

            Assert.AreEqual(schema.Audio, @"https://example.com/sound.mp3");
            Assert.AreEqual(schema.SecureUrl, @"https://secure.example.com/sound.mp3");
            Assert.AreEqual(schema.MimeType, @"audio/mpeg");
        }
    }
}
