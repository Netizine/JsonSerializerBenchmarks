namespace JsonSerializerBenchmarks;

public class Person
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool Active { get; set; }
    public DateTime LastLogin { get; set; }
}

//[JsonSerializable(typeof(Person))]
//[JsonSerializable(typeof(IEnumerable<Person>))]
//[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
//    WriteIndented = false,
//    GenerationMode = JsonSourceGenerationMode.Metadata)]
//public partial class PersonSerializerContext : JsonSerializerContext
//{

//}