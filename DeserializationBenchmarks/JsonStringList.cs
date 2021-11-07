using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.DeserializationBenchmarks
{
    [MemoryDiagnoser]
    public class JsonStringList
    {
        private static string _json;

        [GlobalSetup]
        public static void Setup()
        {
            var people = Enumerable.Range(0, 1000).Select(i => new Person
            {
                Id = i,
                FirstName = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                Phone = Faker.Phone.Number()

            }).ToList();
            _json = JsonSerializer.Serialize(people, PersonSerializerContext.Default.IEnumerablePerson);

        }

        [Benchmark(Baseline = true, Description = "Deserialize string list With reflection")]
        [BenchmarkCategory("String List<Person>")]

        public void DeserializeStringListWithReflection()
        {
            _ = JsonSerializer.Deserialize<IEnumerable<Person>>(_json);
        }

        [Benchmark(Description = "Deserialize string list With serialization context")]
        [BenchmarkCategory("String List<Person>")]
        public void DeserializeStringListWithSerializationContext()
        {
            _ = JsonSerializer.Deserialize(_json, PersonSerializerContext.Default.IEnumerablePerson);
        }

    }
}
