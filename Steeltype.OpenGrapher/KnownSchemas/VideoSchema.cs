namespace Steeltype.OpenGrapher.KnownSchemas
{
    public class VideoSchema : IKnownSchema
    {
        [OpenGraphProperty(@"og:video")]
        public string Video { get; set; }

        [OpenGraphProperty(@"og:video:url")]
        public string Url { get; set; }

        [OpenGraphProperty(@"og:video:secure_url")]
        public string SecureUrl { get; set; }

        [OpenGraphProperty(@"og:video:type")]
        public string MimeType { get; set; }

        [OpenGraphProperty(@"og:video:width")]
        public int? Width { get; set; }

        [OpenGraphProperty(@"og:video:height")]
        public int? Height { get; set; }

        [OpenGraphProperty(@"og:video:alt")]
        public string VideoAlt { get; set; }
    }
}
