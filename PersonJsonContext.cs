using System.Text.Json.Serialization;

namespace JsonSerializerBenchmarks;

[JsonSerializable(typeof(Person))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class PersonJsonContext : JsonSerializerContext
{

}