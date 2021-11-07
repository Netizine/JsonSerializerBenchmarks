using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.SerializationBenchmarks
{

    [MemoryDiagnoser]
    public class JsonListSerializationBenchmarks
    {
        private static List<Person> _people;

        [GlobalSetup]
        public static void Setup()
        {
            _people = Enumerable.Range(0, 1000).Select(i => new Person
            {
                Id = i,
                FirstName = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                Phone = Faker.Phone.Number()
            }).ToList();
        }

        [Benchmark(Baseline = true, Description = "Serialize string list with reflection")]
        public void SerializeListWithReflection()
        {
            _ = JsonSerializer.Serialize(_people);
        }

        [Benchmark(Description = "Serialize string list with serialization context")]
        [BenchmarkCategory("String List<Person>")]
        public void SerializeStringListWithSerializationContext()
        {
            _ = JsonSerializer.Serialize(_people, PersonSerializerContext.Default.IEnumerablePerson);
        }

    }
    
}
