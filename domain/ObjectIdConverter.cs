// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Newtonsoft.Json;
// using MongoDB.Bson;

// class ObjectIdConverter : JsonConverter
// {
//     public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//     {
//         serializer.Serialize(writer, value.ToString());
//     }

//     public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//     {
//         throw new NotImplementedException();
//     }

//     public override bool CanConvert(Type objectType)
//     {
//         return typeof(ObjectId).IsAssignableFrom(objectType);
//     }
// }
