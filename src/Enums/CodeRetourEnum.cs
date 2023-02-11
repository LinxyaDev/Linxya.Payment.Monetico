using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Le résultat du paiement
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=25"/>
    [TypeConverter(typeof(EnumMemberConverter<CodeRetourEnum>))]
    public enum CodeRetourEnum
    {
        /// <summary>
        /// Paiement de test
        /// </summary>
        [EnumMember(Value = "payetest")]
        PayeTest = 0,
        /// <summary>
        /// Paiement
        /// </summary>
        [EnumMember(Value = "paiement")]
        Paiement,
        /// <summary>
        /// Annulation
        /// </summary>
        [EnumMember(Value = "annulation")]
        Annulation,
        /// <summary>
        /// Paiement PF2
        /// </summary>
        [EnumMember(Value = "paiement_pf2")]
        PaiementPf2,
        /// <summary>
        /// Annulation PF2
        /// </summary>
        [EnumMember(Value = "Annulation_pf2")]
        AnnulationPf2,
        /// <summary>
        /// Paiement PF3
        /// </summary>
        [EnumMember(Value = "paiement_pf3")]
        PaiementPf3,
        /// <summary>
        /// Annulation PF3
        /// </summary>
        [EnumMember(Value = "Annulation_pf3")]
        AnnulationPf3,
        /// <summary>
        /// Paiement PF4
        /// </summary>
        [EnumMember(Value = "paiement_pf4")]
        PaiementPf4,
        /// <summary>
        /// Annulation PF4
        /// </summary>
        [EnumMember(Value = "Annulation_pf4")]
        AnnulationPf4,
    }
}
