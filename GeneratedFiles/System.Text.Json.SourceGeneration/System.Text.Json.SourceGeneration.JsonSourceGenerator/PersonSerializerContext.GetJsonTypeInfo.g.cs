﻿// <auto-generated/>
#nullable enable

namespace JsonSerializerBenchmarks
{
    public partial class PersonSerializerContext
    {
        public override global::System.Text.Json.Serialization.Metadata.JsonTypeInfo GetTypeInfo(global::System.Type type)
        {
            if (type == typeof(global::JsonSerializerBenchmarks.Person))
            {
                return this.Person;
            }
        
            if (type == typeof(global::System.Collections.Generic.IEnumerable<global::JsonSerializerBenchmarks.Person>))
            {
                return this.IEnumerablePerson;
            }
        
            return null!;
        }
    }
}
