using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Indique le résultat de l’authentification.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
    public enum AuthStatusEnum
    {
        /// <summary>
        /// L’authentification est effectuée avec succès.
        /// </summary>
        [EnumMember(Value = "authenticated")]
        Authenticated = 0,
        /// <summary>
        /// L'authentification n'a pas pu être complétée (problème technique ou autre).
        /// </summary>
        [EnumMember(Value = "authentication_not_performed")]
        AuthenticationNotPerformed,
        /// <summary>
        /// L'authentification a échoué.
        /// </summary>
        [EnumMember(Value = "not_authenticated")]
        NotAuthenticated,
        /// <summary>
        /// L'authentification a été refusée par l'émetteur.
        /// </summary>
        [EnumMember(Value = "authentication_rejected")]
        AuthenticationRejected,

        /// <summary>
        /// Une tentative d'authentification a bien été effectuée. L'authentification n'a pas pu se faire mais une preuve a été générée (CAVV)
        /// </summary>
        [EnumMember(Value = "authentication_attempted")]
        AuthenticationAttempted,
        /// <summary>
        /// La carte n'est pas enrôlée au 3DS
        /// </summary>
        [EnumMember(Value = "not_enrolled")]
        NotEnrolled,
        /// <summary>
        /// Dans le cas de l’usage de l’option 3DSecure débrayable
        /// </summary>
        [EnumMember(Value = "disabled")]
        Disabled,
    }
}
