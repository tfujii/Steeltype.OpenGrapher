namespace Steeltype.OpenGrapher.KnownSchemas
{
    /// <summary>
    /// The schema "og:image" as described on https://ogp.me/
    /// </summary>
    public class ImageSchema : IKnownSchema
    {
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// An image URL which should represent your object within the graph.
        /// </value>
        [OpenGraphProperty(@"og:image")]
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// Identical to og:image.
        /// </value>
        [OpenGraphProperty(@"og:image:url")]
        public string? Url { get; set; }

        /// <summary>
        /// Gets or sets the secure URL.
        /// </summary>
        /// <value>
        /// An alternate url to use if the webpage requires HTTPS.
        /// </value>
        [OpenGraphProperty(@"og:image:secure_url")]
        public string? SecureUrl { get; set; }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// A MIME type for this image.
        /// </value>
        [OpenGraphProperty(@"og:image:type")]
        public string? MimeType { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The number of pixels wide.
        /// </value>
        [OpenGraphProperty(@"og:image:width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The number of pixels high.
        /// </value>
        [OpenGraphProperty(@"og:image:height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the image alt.
        /// </summary>
        /// <value>
        /// A description of what is in the image (not a caption). If the page specifies an og:image it should specify og:image:alt.
        /// </value>
        [OpenGraphProperty(@"og:image:alt")]
        public string? ImageAlt { get; set; }
    }
}
