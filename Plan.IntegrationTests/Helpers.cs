﻿using System.Text.Json;
using System.Text.Json.Serialization;
using NetTopologySuite.IO.Converters;

namespace Plan.IntegrationTests;

public static class Default
{
    public static JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter(), new GeoJsonConverterFactory() }
    };
}