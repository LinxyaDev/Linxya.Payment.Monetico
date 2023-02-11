using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Indique, s’il est présent uniquement, que le filtrage est en mode « information ».
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
    [TypeConverter(typeof(EnumMemberConverter<FiltrageEtatEnum>))]
    public enum FiltrageEtatEnum
    {
        /// <summary>
        /// Mode information du filtrage
        /// </summary>
        [EnumMember(Value = "information")]
        Information = 0,
    }
}
