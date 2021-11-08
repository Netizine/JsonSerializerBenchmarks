using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;

namespace JsonSerializerBenchmarks;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class JsonSerializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private List<Person> _people = new();

    [GlobalSetup]
    public void Setup()
    {
        Faker<Person> faker = new();
        var startDate = new DateTime(1920, 1, 1);
        var endDate = new DateTime(2003, 12, 31);
        Randomizer.Seed = new Random(420);
        _people = faker
            .RuleFor(x => x.Id, x => x.IndexFaker)
            .RuleFor(x => x.FirstName, x => x.Name.FirstName())
            .RuleFor(x => x.LastName, x => x.Name.LastName())
            .RuleFor(x => x.Email, x => x.Internet.Email())
            .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
            .RuleFor(x => x.BirthDate, x => x.Date.Between(startDate, endDate))
            .RuleFor(x => x.StreetAddress, x => x.Address.StreetAddress())
            .RuleFor(x => x.City, x => x.Address.City())
            .RuleFor(x => x.County, x => x.Address.County())
            .RuleFor(x => x.Country, x => x.Address.Country())
            .RuleFor(x => x.PostalCode, x => x.Address.ZipCode())
            .RuleFor(x => x.Latitude, x => x.Address.Latitude())
            .RuleFor(x => x.Longitude, x => x.Address.Longitude())
            .RuleFor(x => x.Active, x => x.Random.Bool())
            .RuleFor(x => x.LastLogin, x => x.Date.Recent(7))
            .Generate(1000);
    }

    [BenchmarkCategory("Stream"), Benchmark(Baseline = true, Description = "Classic Serializer on List<person> containing 1000 objects")]
    public MemoryStream ClassicSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _people, _options);
        return memoryStream;
    }

    [BenchmarkCategory("Stream"), Benchmark(Description = "Generated Serializer on List<person> containing 1000 objects")]
    public MemoryStream GeneratedSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _people, PeopleJsonContext.Default.IEnumerablePerson);
        return memoryStream;
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string ClassicSerializer_AsString()
    {
        var memoryStream = ClassicSerializer();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    [BenchmarkCategory("String"), Benchmark]
    public string GeneratedSerializer_AsString()
    {
        var memoryStream = GeneratedSerializer();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

}