using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.DeserializationBenchmarks
{
    [MemoryDiagnoser]
    public class JsonString
    {
        private static string _json;

        [GlobalSetup]
        public static void Setup()
        {
            var person = new Person
            {
                Id = 1,
                FirstName = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                Phone = Faker.Phone.Number()
            };

            _json = JsonSerializer.Serialize(person, PersonSerializerContext.Default.Person);
        }

        [Benchmark(Description = "Deserialize string with reflection")]
        [BenchmarkCategory("String Person")]

        public void DeserializeStringWithReflection()
        {
            _ = JsonSerializer.Deserialize<Person>(_json);
        }

        [Benchmark(Description = "Deserialize string with serialization context")]
        [BenchmarkCategory("String Person")]
        public void DeserializeStringWithSerializationContext()
        {
            _ = JsonSerializer.Deserialize(_json, PersonSerializerContext.Default.Person);
        }

   }
}
