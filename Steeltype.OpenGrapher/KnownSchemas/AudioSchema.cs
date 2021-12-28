namespace Steeltype.OpenGrapher.KnownSchemas
{
    public class AudioSchema : IKnownSchema
    {
        [OpenGraphProperty(@"og:audio")]
        public string Audio { get; set; }

        [OpenGraphProperty(@"og:audio:url")]
        public string Url { get; set; }

        [OpenGraphProperty(@"og:audio:secure_url")]
        public string SecureUrl { get; set; }

        [OpenGraphProperty(@"og:audio:type")]
        public string MimeType { get; set; }
    }
}
