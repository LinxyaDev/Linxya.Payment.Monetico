using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Linxya.Payment.Monetico.Converters
{
    /// <summary>
    /// Newtonsoft JSON converter for some specific timestamp fields formatted using ISO 8601
    /// </summary>
    public class Iso8601FullDateTimeJsonConverter : JsonConverter<DateTime>
    {
        private const string Iso8601FullDateTimeFormat = "s";

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact(reader.ReadAsString(), Iso8601FullDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToUniversalTime().ToString(Iso8601FullDateTimeFormat, CultureInfo.InvariantCulture) + 'Z');
        }
    }
}