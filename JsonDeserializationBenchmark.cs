using System.Text;
using BenchmarkDotNet.Attributes;
using static System.Text.Json.JsonSerializer;

namespace JsonSerializerBenchmarks
{
    [MemoryDiagnoser]
    public class JsonDeserializationBenchmarks
    {
        private static string? _serialized;
        private static MemoryStream? _serializedStream;

        [GlobalSetup]
        public static void Setup()
        {
            var rnd = new Random();
            var people = Enumerable.Range(0, 1000).Select(_ => new Person
            {
                FirstName = RandomString.Generate(rnd.Next(3, 8)),
                LastName = RandomString.Generate(rnd.Next(3, 8)),
            }).ToList();
            _serialized = Serialize(people, PersonSerializerContext.Default.IEnumerablePerson);
            _serializedStream = new MemoryStream(Encoding.UTF8.GetBytes(_serialized));
        }

        [IterationSetup]
        public static void ResetStream()
        {
            _ = (_serializedStream?.Seek(0, SeekOrigin.Begin));
        }

        [Benchmark]
        [BenchmarkCategory("string")]
        public void DeserializeStringWithSerializationContext()
        {
            if (_serialized != null)
            {
                _ = Deserialize(_serialized, PersonSerializerContext.Default.IEnumerablePerson);
            }
        }

        [Benchmark]
        [BenchmarkCategory("stream")]
        public void DeserializeStreamWithSerializationContext()
        {
            if (_serializedStream != null)
            {
                _ = Deserialize(_serializedStream, PersonSerializerContext.Default.IEnumerablePerson);
            }
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("string")]

        public void DeserializeStringWithReflection()
        {
            if (_serialized != null)
            {
                _ = Deserialize<IEnumerable<Person>>(_serialized);
            }
        }

        [Benchmark]
        [BenchmarkCategory("stream")]
        public void DeserializeStreamWithReflection()
        {
            if (_serializedStream != null)
            {
                _ = Deserialize<IEnumerable<Person>>(_serializedStream);
            }
        }
    }
}
