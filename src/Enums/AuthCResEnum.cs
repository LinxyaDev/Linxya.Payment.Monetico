using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Le message CRes est la réponse ACS au message CReq.
    /// Il peut indiquer le résultat de l'authentification du titulaire de carte ou, dans le cas d'un modèle basé sur une application,
    /// indiquer également qu'une interaction supplémentaire du titulaire de carte est nécessaire pour mener à bien l'authentification.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=110"/>
    public enum AuthCResEnum
    {
        /// <summary>
        /// Authentification échouée après challenge.
        /// </summary>
        [EnumMember(Value = "N")]
        AuthentificationEchoueeApresChallenge = 0,
        /// <summary>
        /// Authentification réussie après challenge.
        /// </summary>
        [EnumMember(Value = "Y")]
        AuthentificationReussieApresChallenge,
    }
}
