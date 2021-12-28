using Newtonsoft.Json;
using NUnit.Framework;
using Steeltype.OpenGrapher.KnownSchemas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Steeltype.OpenGrapher.Tests
{
    public class SerializationTests
    {
        [Test]
        public async Task ShouldExportOpenGraphAsDictionaryAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            var openGraphDictionary = site.OpenGraphToDictionary();

            var serializedSchema = JsonConvert.SerializeObject(openGraphDictionary);

            var deserializedSchema = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(serializedSchema);

            Assert.AreEqual(openGraphDictionary, deserializedSchema);
        }

        [Test]
        public async Task ShouldExportMetaTagsAsDictionaryAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            var metaTagsDictionary = site.MetaTagsToDictionary();

            var serializedSchema = JsonConvert.SerializeObject(metaTagsDictionary);

            var deserializedSchema = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(serializedSchema);

            Assert.AreEqual(metaTagsDictionary, deserializedSchema);
        }

        [Test]
        public async Task CanSerializeBasicOpenGraphSchemaAsync()
        {
            var site = await OpenGrapher.LoadAsync(TestData.VALID_HTML_BASIC_SCHEMA);

            var schema = site.Extract<BasicSchema>();

            var serializedSchema = JsonConvert.SerializeObject(schema);

            var deserializedSchema = JsonConvert.DeserializeObject<BasicSchema>(serializedSchema);

            Assert.AreEqual(schema, deserializedSchema);
        }
    }
}
