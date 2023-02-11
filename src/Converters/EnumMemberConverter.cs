using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Linxya.Payment.Monetico.Converters
{
    public class EnumMemberConverter<T> : EnumConverter
    {
        public EnumMemberConverter(Type type) : base(type) { }

        public override object ConvertFrom(ITypeDescriptorContext context,
                                           CultureInfo culture,
                                           object value)
        {
            var type = typeof(T);

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute &&
                    value is string enumValue &&
                    string.Compare(attribute.Value, enumValue, true) == 0)
                {
                    return field.GetValue(null);
                }
            }
            object? result = null;
            try
            {
                result = base.ConvertFrom(context, culture, value);
            }
            catch (Exception ex) { }
            return result;
        }
    }
}
