using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Vérification de l’enrôlement d’une carte à 3DSecure 1.X.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=109"/>
    public enum AuthVEResEnum
    {
        /// <summary>
        /// Carte non-enrôlée 3DSecure 1.X.
        /// </summary>
        [EnumMember(Value = "N")]
        CarteNonEnrolee = 0,
        /// <summary>
        /// Carte enrôlée 3DSecure 1.X.
        /// </summary>
        [EnumMember(Value = "Y")]
        CarteEnrolee,
        /// <summary>
        /// Problème technique lors de la vérification de l’éligibilité de la carte
        /// </summary>
        [EnumMember(Value = "U")]
        ProblemeTechnique,
    }
}
