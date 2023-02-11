using Linxya.Payment.Monetico.Enums;
using System.Text.Json.Serialization;

namespace Linxya.Payment.Monetico.Models.Response
{
    /// <summary>
    /// Le champ « details » permet de réaliser une analyse plus fine du déroulé du processus 3DSecure.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
    public class MoneticoAuthenticationDetailsResponse
    {
        /// <summary>
        /// Indique s’il y a transfert de responsabilités vers la banque émettrice.
        /// Chaîne
        /// Valeurs possibles :
        /// « Y » : La banque émettrice supporte le risque.
        /// « N » : Le marchand supporte le risque.
        /// « NA »: Impossible à déterminer ou non applicable.
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 2.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
        public AuthLiabilityShiftEnum? LiabilityShift { get; set; }
        /// <summary>
        /// Vérification de l’enrôlement d’une carte à 3DSecure 1.X.
        /// Chaîne
        /// Valeurs possibles :
        /// « Y » : carte enrôlée 3DSecure 1.X.
        /// « N » : carte non-enrôlée 3DSecure 1.X.
        /// « U » : Problème technique lors de la vérification de l’éligibilité de la carte
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 1.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
        public AuthVEResEnum? VERes { get; set; }
        /// <summary>
        /// Résultat de l’authentification 3DSecure.
        /// Chaîne
        /// Valeurs possibles :
        /// « Y » : Authentification réussie.
        /// « U » : Problème technique lors de l’authentification.
        /// « N » : Authentification échouée.
        /// « A » : Pas d’authentification mais la banque du porteur prend en charge le risque.
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 1.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
        public AuthPAResEnum? PARes { get; set; }
        /// <summary>
        /// Le message ARes est la réponse ACS de l’émetteur au message AReq.
        /// Cela peut indiquer que le titulaire de la carte a été authentifié
        /// ou qu'une interaction supplémentaire entre le titulaire de la carte est nécessaire pour mener à bien l'authentification.
        /// Il n'y a qu'un seul message ARES par transaction.
        /// Chaîne
        /// Valeurs possibles :
        /// « Y » : Authentification réussie sans challenge.
        /// « R » : Authentification refusée par l'émetteur
        /// « C » : Challenge demandé.
        /// « U » : L’ACS n’a pas répondu correctement.
        /// « A » : L'authentification n'a pas pu se faire mais une preuve a été générée.
        /// « N » : Authentification échouée sans challenge.
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 2.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=110"/>
        public AuthAResEnum? ARes { get; set; }
        /// <summary>
        /// Le message CRes est la réponse ACS au message CReq.
        /// Il peut indiquer le résultat de l'authentification du titulaire de carte ou, dans le cas d'un modèle basé sur une application,
        /// indiquer également qu'une interaction supplémentaire du titulaire de carte est nécessaire pour mener à bien l'authentification.
        /// Chaîne
        /// Valeurs possibles :
        /// « Y » : Authentification réussie après challenge.
        /// « N » : Authentification échouée après challenge.
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 2.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=110"/>
        public AuthCResEnum? CRes { get; set; }
        /// <summary>
        /// Indique le souhait du commerçant concernant la cinématique de l’authentification 3DSecure 2.X.
        /// Il s’agit uniquement d’un souhait et ce dernier peut ne pas être approuvé par les banques émettrices.
        /// Chaîne
        /// Valeurs possibles :
        /// « no_preference » : pas de préférence (choix par défaut)
        /// « challenge_preferred » : challenge souhaité
        /// « challenge_mandated » : challenge requis
        /// « no_challenge_requested » : pas de challenge demandé
        /// « no_challenge_requested_strong_authentication » : pas de challenge demandé
        ///  -> l’authentification forte du client a déjà été réalisée par le commerçant.
        /// « no_challenge_requested_trusted_third_party » : pas de challenge demandé
        ///  –> demande d’exemption car le commerçant est un bénéficiaire de confiance du client.
        /// « no_challenge_requested_risk_analysis » : pas de challenge demandé
        ///  –> demande d’exemption pour un autre motif que cité précédemment(par exemple : petit montant)
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=110"/>
        public AuthThreeDSecurePreference? MerchantPreference { get; set; }
        /// <summary>
        /// Identifiant unique lié à la transaction.
        /// Chaîne au format UUID (RFC 4122)
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 2.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=111"/>
        public string? TransactionID { get; set; }
        /// <summary>
        /// Indicateur d’échange 3DSecure 1.X
        /// Entier
        /// Valeurs possibles :
        ///  -1 : la transaction ne s’est pas faite selon le protocole 3DSecure et le risque d’impayé est élevé
        ///  1 : la transaction s’est faite selon le protocole 3DS et le risque d’impayé est faible
        ///  4 : la transaction s’est faite selon le protocole 3DS et le risque d’impayé est élevé
        /// </summary>
        /// <remarks>
        /// Dans le cadre de 3DSecure 1.X uniquement.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=111"/>
        public AuthStatus3DS? Status3DS { get; set; }
        /// <summary>
        /// Couplé à l’option de 3DSecure débrayable. Indique le motif du débrayage.
        /// Chaîne
        /// Valeurs possibles :
        ///  commercant : débrayage explicite par le commerçant via l’envoi de la valeur appropriée dans le formulaire de la phase « Aller »
        ///  seuilnonatteint : débrayage car le montant de la transaction n’atteint pas le montant configuré par le commerçant
        ///  scoring : débrayage sur motif de scoring
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=111"/>
        public AuthDisablingReasonEnum? DisablingReason { get; set; }

    }
}
