using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace JsonSerializerBenchmarks.SerializationBenchmarks
{

    [MemoryDiagnoser]
    public class JsonStringSerializationBenchmarks
    {
        private static Person _person;

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
        }



        [Benchmark(Baseline = true, Description = "Serialize string with reflection")]
        public void SerializeWithReflection()
        {
            _ = JsonSerializer.Serialize(_person);
        }

        [Benchmark(Description = "Serialize string with serialization context")]
        [BenchmarkCategory("String Person")]
        public void SerializeStringWithSerializationContext()
        {
            _ = JsonSerializer.Serialize(_person, PersonSerializerContext.Default.Person);
        }

    }
    
}
