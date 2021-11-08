using System.Text.Json.Serialization;

namespace JsonSerializerBenchmarks;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(IEnumerable<Person>))]
public partial class PeopleJsonContext : JsonSerializerContext
{
}