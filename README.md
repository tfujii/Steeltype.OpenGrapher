# Steeltype.OpenGrapher
A simple HTML parser for extracting OpenGraph schemas.

[![.NET](https://github.com/tfujii/Steeltype.OpenGrapher/actions/workflows/dotnet.yml/badge.svg)](https://github.com/tfujii/Steeltype.OpenGrapher/actions/workflows/dotnet.yml)

# Use:
```C#
using Steeltype.OpenGrapher;
using Steeltype.OpenGrapher.KnownSchemas;

var site = OpenGrapher.ParseSite("html string containing opengraph markup");
var basicSchema = site.Extract<BasicSchema>();
var imageSchema = site.Extract<ImageSchema>();

Console.WriteLine("OpenGraph Title: " + basicSchema.Title);
Console.WriteLine("OpenGraph Image: " + imageSchema.Image);
```
