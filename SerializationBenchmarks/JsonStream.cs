using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.SerializationBenchmarks
{

    [MemoryDiagnoser]
    public class JsonStream
    {
        private static Person _person;
        private static MemoryStream _memoryStream;

        [GlobalSetup]
        public static void Setup()
        {
            _person = new Person
            {
                Id = 1,
                FirstName = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                Phone = Faker.Phone.Number()
            };
            var serialized = JsonSerializer.Serialize(_person, PersonSerializerContext.Default.Person);
            _memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(serialized));
        }

        [IterationSetup]
        public static void ResetStream()
        {
            _memoryStream = new MemoryStream();
        }


        [Benchmark(Baseline = true, Description = "Serialize stream with reflection")]
        public void SerializeStreamWithReflection()
        {
            _ = JsonSerializer.Serialize(_memoryStream);
        }

        [Benchmark(Description = "Serialize stream with serialization context")]
        [BenchmarkCategory("Stream Person")]
        public void SerializeStreamWithSerializationContext()
        {
            var writer = new Utf8JsonWriter(_memoryStream);
            JsonSerializer.Serialize(writer, _person, PersonSerializerContext.Default.Person);
        }

    }
    
}
