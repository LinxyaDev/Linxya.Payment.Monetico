using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Type de facture à générer pour les TPE en pré autorisation.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
    [TypeConverter(typeof(EnumMemberConverter<TypeFactureEnum>))]
    public enum TypeFactureEnum
    {
        /// <summary>
        /// Pré-auto
        /// </summary>
        [EnumMember(Value = "preauto")]
        PreAuto = 0,
    }
}
