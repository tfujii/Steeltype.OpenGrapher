namespace Steeltype.OpenGrapher.KnownSchemas
{
    public class ImageSchema : IKnownSchema
    {
        [OpenGraphProperty(@"og:image")]
        public string Image { get; set; }

        [OpenGraphProperty(@"og:image:url")]
        public string Url { get; set; }

        [OpenGraphProperty(@"og:image:secure_url")]
        public string SecureUrl { get; set; }

        [OpenGraphProperty(@"og:image:type")]
        public string MimeType { get; set; }

        [OpenGraphProperty(@"og:image:width")]
        public int? Width { get; set; }

        [OpenGraphProperty(@"og:image:height")]
        public int? Height { get; set; }

        [OpenGraphProperty(@"og:image:alt")]
        public string ImageAlt { get; set; }
    }
}
