﻿// <auto-generated/>
#nullable enable

namespace JsonSerializerCodegen
{
    public partial class PersonSerializerContext
    {
        private global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>>? _IEnumerableOldPerson;
        public global::System.Text.Json.Serialization.Metadata.JsonTypeInfo<global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>> IEnumerableOldPerson
        {
            get
            {
                if (_IEnumerableOldPerson == null)
                {
                    global::System.Text.Json.Serialization.JsonConverter? customConverter;
                    if (Options.Converters.Count > 0 && (customConverter = GetRuntimeProvidedCustomConverter(typeof(global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>))) != null)
                    {
                        _IEnumerableOldPerson = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateValueInfo<global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>>(Options, customConverter);
                    }
                    else
                    {
                        global::System.Text.Json.Serialization.Metadata.JsonCollectionInfoValues<global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>> info = new global::System.Text.Json.Serialization.Metadata.JsonCollectionInfoValues<global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>>()
                            {
                                ObjectCreator = null,
                                KeyInfo = null,
                                ElementInfo = this.OldPerson,
                                NumberHandling = default,
                                SerializeHandler = IEnumerableOldPersonSerializeHandler
                            };
            
                            _IEnumerableOldPerson = global::System.Text.Json.Serialization.Metadata.JsonMetadataServices.CreateIEnumerableInfo<global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson>, global::JsonSerializerCodegen.OldPerson>(Options, info);
            
                    }
                }
        
                return _IEnumerableOldPerson;
            }
        }
        
        private static void IEnumerableOldPersonSerializeHandler(global::System.Text.Json.Utf8JsonWriter writer, global::System.Collections.Generic.IEnumerable<global::JsonSerializerCodegen.OldPerson> value)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
        
            writer.WriteStartArray();
        
            foreach (global::JsonSerializerCodegen.OldPerson element in value)
            {
                OldPersonSerializeHandler(writer, element);
            }
        
            writer.WriteEndArray();
        }
    }
}
