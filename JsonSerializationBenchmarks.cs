using System.Text.Json;
using BenchmarkDotNet.Attributes;
using static System.Text.Json.JsonSerializer;

namespace JsonSerializerBenchmarks
{
    [MemoryDiagnoser]
    public class JsonSerializationBenchmarks
    {
        private static List<Person>? _people;
        private static MemoryStream? _stream;

        [GlobalSetup]
        public static void Setup()
        {
            var rnd = new Random();
            _people = Enumerable.Range(0, 1000).Select(_ => new Person
            {
                FirstName = RandomString.Generate(rnd.Next(3, 7)),
                LastName = RandomString.Generate(rnd.Next(3, 7)),
            }).ToList();
            _stream = new MemoryStream();
        }

        [IterationSetup]
        public static void ResetStream()
        {
            _stream = new MemoryStream();
        }


        [Benchmark(Baseline = true)]
        public void SerializeWithReflection()
        {
            _ = Serialize(_people);
        }

        [Benchmark]
        [BenchmarkCategory("string")]
        public void SerializeStringWithSerializationContext()
        {
            if (_people != null)
            {
                _ = Serialize(_people, PersonSerializerContext.Default.IEnumerablePerson);
            }
        }

        [Benchmark]
        [BenchmarkCategory("stream")]
        public void SerializeStreamWithSerializationContext()
        {
            if (_stream == null || _people == null) return;
            var writer = new Utf8JsonWriter(_stream);
            Serialize(writer, _people, PersonSerializerContext.Default.IEnumerablePerson);
        }

    }
}
