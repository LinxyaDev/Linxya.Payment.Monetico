using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Protocole utilisé pour l’authentification.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
    public enum AuthProtocolEnum
    {
        /// <summary>
        /// 3DSecure
        /// </summary>
        [EnumMember(Value = "3DSecure")]
        ThreeDSecure = 0,
    }
}
