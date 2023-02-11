using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Couplé à l’option de 3DSecure débrayable. Indique le motif du débrayage.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=111"/>
    public enum AuthDisablingReasonEnum
    {
        /// <summary>
        /// Débrayage explicite par le commerçant via l’envoi de la valeur appropriée dans le formulaire de la phase « Aller »
        /// </summary>
        [EnumMember(Value = "commercant")]
        Commercant = 0,
        /// <summary>
        /// Débrayage car le montant de la transaction n’atteint pas le montant configuré par le commerçant
        /// </summary>
        [EnumMember(Value = "seuilnonatteint")]
        SeuilNonAtteint,
        /// <summary>
        /// Débrayage sur motif de scoring
        /// </summary>
        [EnumMember(Value = "scoring")]
        Scoring,
    }
}
