using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Précise le type de carte utilisée pour réaliser la transaction.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
    [TypeConverter(typeof(EnumMemberConverter<UsageEnum>))]
    public enum UsageEnum
    {
        /// <summary>
        /// Impossible de déterminer le type de carte
        /// </summary>
        [EnumMember(Value = "inconnu")]
        Inconnu = 0,
        /// <summary>
        /// Carte de crédit
        /// </summary>
        [EnumMember(Value = "credit")]
        Credit,
        /// <summary>
        /// Carte de débit
        /// </summary>
        [EnumMember(Value = "debit")]
        Debit,
        /// <summary>
        /// Carte prépayée
        /// </summary>
        [EnumMember(Value = "prepaye")]
        Prepaye,
    }
}
