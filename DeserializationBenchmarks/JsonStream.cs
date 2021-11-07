using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.DeserializationBenchmarks
{
    [MemoryDiagnoser]
    public class JsonStream
    {
        private static MemoryStream _memoryStream;

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

            var json = JsonSerializer.Serialize(person, PersonSerializerContext.Default.Person);
            _memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        }

        [IterationSetup]
        public static void ResetStream()
        {
            _memoryStream.Seek(0, SeekOrigin.Begin);
        }

        [Benchmark(Baseline = true, Description = "Deserialize stream with reflection")]
        [BenchmarkCategory("Stream Person")]
        public void DeserializeStreamWithReflection()
        {
            _ = JsonSerializer.Deserialize<Person>(_memoryStream);
        }

        [Benchmark(Description = "Deserialize stream with serialization context")]
        [BenchmarkCategory("Stream Person")]
        public void DeserializeStreamWithSerializationContext()
        {
            _ = JsonSerializer.Deserialize(_memoryStream, PersonSerializerContext.Default.Person);
        }

    }
}
