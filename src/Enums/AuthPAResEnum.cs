using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Résultat de l’authentification 3DSecure.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
    public enum AuthPAResEnum
    {
        /// <summary>
        /// Authentification échouée.
        /// </summary>
        [EnumMember(Value = "N")]
        AuthentificationEchouee = 0,
        /// <summary>
        /// Authentification réussie.
        /// </summary>
        [EnumMember(Value = "Y")]
        AuthentificationReussie,
        /// <summary>
        /// Problème technique lors de l’authentification.
        /// </summary>
        [EnumMember(Value = "U")]
        ProblemeTechnique,
        /// <summary>
        /// Pas d’authentification mais la banque du porteur prend en charge le risque.
        /// </summary>
        [EnumMember(Value = "A")]
        PasAuthentificationMaisPriseRisque,
    }
}
