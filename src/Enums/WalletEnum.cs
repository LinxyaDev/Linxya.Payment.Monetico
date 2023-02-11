using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Nom du wallet utilisé pour le paiement uniquement dans le cas Paylib.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
    [TypeConverter(typeof(EnumMemberConverter<WalletEnum>))]
    public enum WalletEnum
    {
        /// <summary>
        /// Paylib
        /// </summary>
        [EnumMember(Value = "paylib")]
        Paylib = 0,
    }
}
