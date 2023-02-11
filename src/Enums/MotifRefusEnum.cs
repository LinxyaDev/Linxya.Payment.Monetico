using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Motif du refus de la demande de paiement.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
    [TypeConverter(typeof(EnumMemberConverter<MotifRefusEnum>))]
    public enum MotifRefusEnum
    {
        /// <summary>
        /// La banque du client demande des informations complémentaires
        /// </summary>
        [EnumMember(Value = "Appel Phonie")]
        AppelPhonie = 0,
        /// <summary>
        /// La banque du commerçant ou du client refuse d’accorder l’autorisation
        /// </summary>
        [EnumMember(Value = "Refus")]
        Refus,
        /// <summary>
        /// la banque du commerçant ou du client refuse d’accorder l’autorisation
        /// </summary>
        [EnumMember(Value = "Interdit")]
        Interdit,
        /// <summary>
        /// la demande de paiement a été bloquée par le paramétrage de filtrage que le commerçant a mis en place dans son Module Prévention Fraude
        /// </summary>
        [EnumMember(Value = "filtrage")]
        Filtrage,
        /// <summary>
        /// La demande de paiement a été bloquée par le paramétrage de scoring que le commerçant a mis en place dans son Module Prévention Fraude
        /// </summary>
        [EnumMember(Value = "scoring")]
        Scoring,
        /// <summary>
        /// Si le refus est lié à une authentification 3DSecure négative reçue de la banque du porteur
        /// </summary>
        [EnumMember(Value = "3DSecure")]
        ThreeDSecure,
    }
}
