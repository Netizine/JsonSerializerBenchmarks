using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.DeserializationBenchmarks
{
    [MemoryDiagnoser]
    public class JsonStreamList
    {
        private static MemoryStream _memoryStream;

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
            var json = JsonSerializer.Serialize(people, PersonSerializerContext.Default.IEnumerablePerson);
            _memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

        }

        [IterationSetup]
        public static void ResetStream()
        {
            _memoryStream.Seek(0, SeekOrigin.Begin);
        }

        [Benchmark(Baseline = true, Description = "Deserialize stream list With reflection")]
        [BenchmarkCategory("Stream List<Person>")]
        public void DeserializeStreamListWithReflection()
        {
            _ = JsonSerializer.Deserialize<IEnumerable<Person>>(_memoryStream);
        }


        [Benchmark(Description = "Deserialize stream list With serialization context")]
        [BenchmarkCategory("Stream  List<Person>")]
        public void DeserializeStreamListWithSerializationContext()
        {
            _ = JsonSerializer.Deserialize(_memoryStream, PersonSerializerContext.Default.IEnumerablePerson);
        }

   }
}
