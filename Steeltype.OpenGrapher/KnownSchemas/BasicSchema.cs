namespace Steeltype.OpenGrapher.KnownSchemas
{
    using System;
    using System.Linq;

    public class BasicSchema : IKnownSchema, IEquatable<BasicSchema>
    {
        // Required Properties
        [OpenGraphProperty(@"og:title")]
        public string Title { get; set; }

        [OpenGraphProperty(@"og:type")]
        public string Type { get; set; }

        [OpenGraphProperty(@"og:image")]
        public string Image { get; set; }

        [OpenGraphProperty(@"og:url")]
        public string Url { get; set; }

        // Optional Properties
        [OpenGraphProperty(@"og:audio")]
        public string AudioUrl { get; set; }

        [OpenGraphProperty(@"og:description")]
        public string Description { get; set; }

        [OpenGraphProperty(@"og:determiner")]
        public string Determiner { get; set; }

        [OpenGraphProperty(@"og:locale")]
        public string Locale { get; set; }

        [OpenGraphProperty(@"og:locale:alternate")]
        public string[] LocaleAlternates { get; set; }

        [OpenGraphProperty(@"og:site_name")]
        public string SiteName { get; set; }

        [OpenGraphProperty(@"og:video")]
        public string VideoUrl { get; set; }

        /// <inheritdoc/>
        public bool Equals(BasicSchema? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (!other.Title.Equals(this.Title)) return false;
            if (!other.Type.Equals(this.Type)) return false;
            if (!other.Image.Equals(this.Image)) return false;
            if (!other.Url.Equals(this.Url)) return false;

            if (!other.AudioUrl.Equals(this.AudioUrl)) return false;
            if (!other.Description.Equals(this.Description)) return false;
            if (!other.Determiner.Equals(this.Determiner)) return false;
            if (!other.Locale.Equals(this.Locale)) return false;
            if (!Enumerable.SequenceEqual(other.LocaleAlternates, this.LocaleAlternates)) return false;
            if (!other.VideoUrl.Equals(this.VideoUrl)) return false;

            return true;
        }
    }
}
