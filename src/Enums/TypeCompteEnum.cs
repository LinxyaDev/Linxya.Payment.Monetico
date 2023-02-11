using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Précise le type de compte associé à la carte de paiement.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
    [TypeConverter(typeof(EnumMemberConverter<TypeCompteEnum>))]
    public enum TypeCompteEnum
    {
        /// <summary>
        /// Impossible de déterminer le type de compte
        /// </summary>
        [EnumMember(Value = "inconnu")]
        Inconnu = 0,
        /// <summary>
        /// Compte d’un particulier
        /// </summary>
        [EnumMember(Value = "particulier")]
        Particulier,
        /// <summary>
        /// Compte d’un professionnel
        /// </summary>
        [EnumMember(Value = "commercial")]
        Commercial,
    }
}
