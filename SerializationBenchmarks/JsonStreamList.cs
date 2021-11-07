using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.SerializationBenchmarks
{

    [MemoryDiagnoser]
    public class JsonStreamList
    {
        private static List<Person> _people;
        private static MemoryStream _memoryStream;

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
            var serialized = JsonSerializer.Serialize(_people, PersonSerializerContext.Default.IEnumerablePerson);
            _memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(serialized));
        }

        [IterationSetup]
        public static void ResetStream()
        {
            _memoryStream = new MemoryStream();
        }


        [Benchmark(Baseline = true, Description = "Serialize string list with reflection")]
        public void SerializeStreamListWithReflection()
        {
            _ = JsonSerializer.Serialize(_memoryStream);
        }

        [Benchmark(Description = "Serialize stream list with serialization context")]
        [BenchmarkCategory("Stream List<Person>")]
        public void SerializeStreamListWithSerializationContext()
        {
            var writer = new Utf8JsonWriter(_memoryStream);
            JsonSerializer.Serialize(writer, _people, PersonSerializerContext.Default.IEnumerablePerson);
        }

    }
    
}
