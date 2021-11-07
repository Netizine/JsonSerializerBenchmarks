using System.Text.Json.Serialization;

namespace JsonSerializerBenchmarks
{
    public class Person
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
}

    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(IEnumerable<Person>))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        WriteIndented = false,
        GenerationMode = JsonSourceGenerationMode.Metadata)]
    public partial class PersonSerializerContext : JsonSerializerContext
    {

    }
}
