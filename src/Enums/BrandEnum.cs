using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Code réseau de la carte
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
    [TypeConverter(typeof(EnumMemberConverter<BrandEnum>))]
    public enum BrandEnum
    {
        /// <summary>
        /// Non disponible
        /// </summary>
        [EnumMember(Value = "na")]
        NonDisponible = 0,
        /// <summary>
        /// American Express
        /// </summary>
        [EnumMember(Value = "American Express")]
        AmericanExpress,
        /// <summary>
        /// GIE CB
        /// </summary>
        [EnumMember(Value = "CB")]
        CB,
        /// <summary>
        /// Mastercard
        /// </summary>
        [EnumMember(Value = "MC")]
        Mastercard,
        /// <summary>
        /// Visa
        /// </summary>
        [EnumMember(Value = "VI")]
        Visa,
    }
}
