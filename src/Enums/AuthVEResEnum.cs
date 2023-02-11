using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Indique s’il y a transfert de responsabilités vers la banque émettrice.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
    public enum AuthLiabilityShiftEnum
    {
        /// <summary>
        /// Impossible à déterminer ou non applicable.
        /// </summary>
        [EnumMember(Value = "NA")]
        NonApplicable = 0,
        /// <summary>
        /// Le marchand supporte le risque.
        /// </summary>
        [EnumMember(Value = "N")]
        MarchandSupporteRisque,
        /// <summary>
        /// La banque émettrice supporte le risque.
        /// </summary>
        [EnumMember(Value = "Y")]
        BanqueSupporteRisque,
    }
}
