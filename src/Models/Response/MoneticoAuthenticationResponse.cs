using Linxya.Payment.Monetico.Enums;

namespace Linxya.Payment.Monetico.Models.Response
{
    /// <summary>
    /// Document JSON « authentification »
    /// </summary>
    /// <remarks>
    /// Ce champ contient des informations relatives à l’authentification du porteur et est fourni lors de la phase « Retour ».
    /// Si aucune authentification n’a lieu (par exemple paiement bloqué en amont par le module prévention fraude, utilisation de moyens de paiement alternatifs tels que COFIDIS),
    /// le champ sera toujours renvoyé mais valorisé à null c’est-à-dire bnVsbAo = une fois encodé.
    /// </remarks>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
    public class MoneticoAuthenticationResponse
    {
        /// <summary>
        /// Indique le résultat de l’authentification.
        /// Valeurs possibles :
        /// - « authenticated » : L’authentification est effectuée avec succès.
        /// - « authentication_not_performed » : L'authentification n'a pas pu être complétée (problème technique ou autre).
        /// - « not_authenticated »: L'authentification a échoué.
        /// - « authentication_rejected »: L'authentification a été refusée par l'émetteur.
        /// - « authentication_attempted » : Une tentative d'authentification a bien été effectuée. L'authentification n'a pas pu se faire mais une preuve a été générée (CAVV)
        /// - « not_enrolled » : La carte n'est pas enrôlée au 3DS
        /// - « disabled » : Dans le cas de l’usage de l’option 3DSecure débrayable
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
        public AuthStatusEnum? Status { get; set; }
        /// <summary>
        /// Protocole utilisé pour l’authentification.
        /// Chaîne
        /// Valeurs possibles :
        ///  3DSecure
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
        public AuthProtocolEnum? Protocol { get; set; }
        /// <summary>
        /// Version du protocole.
        /// Chaîne
        /// Valeurs possibles :
        ///  1.0.2
        ///  2.1.0
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
        public string? Version { get; set; }
        /// <summary>
        /// Le champ « details » permet de réaliser une analyse plus fine du déroulé du processus 3DSecure.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
        public MoneticoAuthenticationDetailsResponse? Details { get; set; }
    }
}
