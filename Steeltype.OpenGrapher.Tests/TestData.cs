namespace Steeltype.OpenGrapher.Tests
{
    public static class TestData
    {
        public const string VALID_HTML_BASIC_SCHEMA = @"
        <!DOCTYPE html>
        <html>
          <head prefix=""og: https://ogp.me/ns#"">
            <meta charset=""utf-8"">
            <title>The Open Graph protocol</title>
            <meta name=""description"" content=""The Open Graph protocol enables any web page to become a rich object in a social graph."">
            <meta name=""robots"" content=""index,follow,noodp,noydir"">
            <meta name=""viewport"" content=""width=device-width,initial-scale=1,user-scalable=yes"">
            <script type=""text/javascript"">var _sf_startpt=(new Date()).getTime()</script>
            <link rel=""stylesheet"" href=""base.css"" type=""text/css"">
            <meta property=""og:title"" content=""Open Graph protocol"">
            <meta property=""og:type"" content=""website"">
            <meta property=""og:url"" content=""https://ogp.me/"">
            <meta property=""og:image"" content=""https://ogp.me/logo.png"">
            <meta property=""og:image:type"" content=""image/png"">
            <meta property=""og:image:width"" content=""300"">
            <meta property=""og:image:height"" content=""300"">
            <meta property=""og:image:alt"" content=""The Open Graph logo"">
            <meta property=""og:description"" content=""The Open Graph protocol enables any web page to become a rich object in a social graph."">
            <meta prefix=""fb: https://ogp.me/ns/fb#"" property=""fb:app_id"" content=""115190258555800"">
            <meta property=""og:audio"" content=""https://example.com/bond/theme.mp3"" />
            <meta property=""og:description"" 
                content=""Sean Connery found fame and fortune as the
                        suave, sophisticated British agent, James Bond."" />
            <meta property=""og:determiner"" content=""the"" />
            <meta property=""og:locale"" content=""en_GB"" />
            <meta property=""og:locale:alternate"" content=""fr_FR"" />
            <meta property=""og:locale:alternate"" content=""es_ES"" />
            <meta property=""og:site_name"" content=""IMDb"" />
            <meta property=""og:video"" content=""https://example.com/bond/trailer.swf"" />
            <link rel=""alternate"" type=""application/rdf+xml"" href=""https://ogp.me/ns/ogp.me.rdf"">
            <link rel=""alternate"" type=""text/turtle"" href=""https://ogp.me/ns/ogp.me.ttl"">
          </head>
          <body>
          </body>
        </html>
        ";

        public const string EXPECTED_BASIC_SCHEMA_OPENGRAPH_TAGS = @"
        <meta property=""og:title"" content=""Open Graph protocol"" />
        <meta property=""og:type"" content=""website"" />
        <meta property=""og:url"" content=""https://ogp.me/"" />
        <meta property=""og:image"" content=""https://ogp.me/logo.png"" />
        <meta property=""og:image:type"" content=""image/png"" />
        <meta property=""og:image:width"" content=""300"" />
        <meta property=""og:image:height"" content=""300"" />
        <meta property=""og:image:alt"" content=""The Open Graph logo"" />
        <meta property=""og:description"" content=""The Open Graph protocol enables any web page to become a rich object in a social graph."" />
        <meta property=""og:description"" content=""Sean Connery found fame and fortune as the
                                suave, sophisticated British agent, James Bond."" />
        <meta property=""og:audio"" content=""https://example.com/bond/theme.mp3"" />
        <meta property=""og:determiner"" content=""the"" /><meta property=""og:locale"" content=""en_GB"" />
        <meta property=""og:locale:alternate"" content=""fr_FR"" />
        <meta property=""og:locale:alternate"" content=""es_ES"" />
        <meta property=""og:site_name"" content=""IMDb"" />
        <meta property=""og:video"" content=""https://example.com/bond/trailer.swf"" />
        ";

        public static readonly string EXPECTED_BASIC_SCHEMA_META_TAGS = @"
        <meta property=""description"" content=""The Open Graph protocol enables any web page to become a rich object in a social graph."" />
        <meta property=""robots"" content=""index,follow,noodp,noydir"" />
        <meta property=""viewport"" content=""width=device-width,initial-scale=1,user-scalable=yes"" />
        ";

        public const string VALID_HTML_IMAGE_SCHEMA = @"
        <meta property=""og:image"" content=""https://example.com/ogp.jpg"" />
        <meta property=""og:image:secure_url"" content=""https://secure.example.com/ogp.jpg"" />
        <meta property=""og:image:type"" content=""image/jpeg"" />
        <meta property=""og:image:width"" content=""400"" />
        <meta property=""og:image:height"" content=""300"" />
        <meta property=""og:image:alt"" content=""A shiny red apple with a bite taken out"" />
        ";

        public const string VALID_HTML_VIDEO_SCHEMA = @"
        <meta property=""og:video"" content=""https://example.com/movie.swf"" />
        <meta property=""og:video:secure_url"" content=""https://secure.example.com/movie.swf"" />
        <meta property=""og:video:type"" content=""application/x-shockwave-flash"" />
        <meta property=""og:video:width"" content=""400"" />
        <meta property=""og:video:height"" content=""300"" />
        ";

        public const string VALID_HTML_AUDIO_SCHEMA = @"
        <meta property=""og:audio"" content=""https://example.com/sound.mp3"" />
        <meta property=""og:audio:secure_url"" content=""https://secure.example.com/sound.mp3"" />
        <meta property=""og:audio:type"" content=""audio/mpeg"" />
        ";
    }
}
