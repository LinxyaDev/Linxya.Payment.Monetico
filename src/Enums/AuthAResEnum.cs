using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Le message ARes est la réponse ACS de l’émetteur au message AReq.
    /// Cela peut indiquer que le titulaire de la carte a été authentifié
    /// ou qu'une interaction supplémentaire entre le titulaire de la carte est nécessaire pour mener à bien l'authentification.
    /// Il n'y a qu'un seul message ARES par transaction.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=110"/>
    public enum AuthAResEnum
    {
        /// <summary>
        /// Authentification échouée sans challenge.
        /// </summary>
        [EnumMember(Value = "N")]
        AuthentificationEchoueeSansChallenge = 0,
        /// <summary>
        /// Authentification réussie sans challenge.
        /// </summary>
        [EnumMember(Value = "Y")]
        AuthentificationReussieSansChallenge,
        /// <summary>
        /// Authentification refusée par l'émetteur
        /// </summary>
        [EnumMember(Value = "R")]
        AuthentificationRefusee,
        /// <summary>
        /// Challenge demandé.
        /// </summary>
        [EnumMember(Value = "C")]
        ChallengeDemande,
        /// <summary>
        /// L’ACS n’a pas répondu correctement.
        /// </summary>
        [EnumMember(Value = "U")]
        ACSNonRepondu,
        /// <summary>
        /// L'authentification n'a pas pu se faire mais une preuve a été générée.
        /// </summary>
        [EnumMember(Value = "A")]
        AuthentificationEchoueeAvecPreuve,
    }
}
