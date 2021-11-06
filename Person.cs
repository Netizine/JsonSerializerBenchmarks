using System.Text.Json.Serialization;

namespace JsonSerializerBenchmarks
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(IEnumerable<Person>))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    public partial class PersonSerializerContext : JsonSerializerContext
    {

    }
}
