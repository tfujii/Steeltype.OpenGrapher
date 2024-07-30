using NUnit.Framework;
using Steeltype.OpenGrapher.KnownSchemas;
using System.Threading.Tasks;

namespace Steeltype.OpenGrapher.Tests
{
    [TestFixture]
    public class SchemaTests
    {
        [Test]
        public async Task CanExtractOpenGraphImageSchemaAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_IMAGE_SCHEMA);

            var schema = site.Extract<ImageSchema>();

            Assert.That(schema.Image, Is.EqualTo("https://example.com/ogp.jpg"));
            Assert.That(schema.SecureUrl, Is.EqualTo("https://secure.example.com/ogp.jpg"));
            Assert.That(schema.MimeType, Is.EqualTo("image/jpeg"));
            Assert.That(schema.Width, Is.EqualTo(400));
            Assert.That(schema.Height, Is.EqualTo(300));
            Assert.That(schema.ImageAlt, Is.EqualTo("A shiny red apple with a bite taken out"));
        }

        [Test]
        public async Task CanExtractOpenGraphVideoSchemaAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_VIDEO_SCHEMA);

            var schema = site.Extract<VideoSchema>();

            Assert.That(schema.Video, Is.EqualTo("https://example.com/movie.swf"));
            Assert.That(schema.SecureUrl, Is.EqualTo("https://secure.example.com/movie.swf"));
            Assert.That(schema.MimeType, Is.EqualTo("application/x-shockwave-flash"));
            Assert.That(schema.Width, Is.EqualTo(400));
            Assert.That(schema.Height, Is.EqualTo(300));
            Assert.That(schema.VideoAlt, Is.Null);
        }

        [Test]
        public async Task CanExtractOpenGraphAudioSchemaAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_AUDIO_SCHEMA);

            var schema = site.Extract<AudioSchema>();

            Assert.That(schema.Audio, Is.EqualTo("https://example.com/sound.mp3"));
            Assert.That(schema.SecureUrl, Is.EqualTo("https://secure.example.com/sound.mp3"));
            Assert.That(schema.MimeType, Is.EqualTo("audio/mpeg"));
        }
    }
}
