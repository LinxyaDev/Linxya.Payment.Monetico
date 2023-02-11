using System.ComponentModel;
using System.Runtime.Serialization;
using Linxya.Payment.Monetico.Converters;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Moyen de paiement utilisé.
    /// </summary>
    /// <remarks>
    /// Payment protocols supported by the Monetico Payment page
    /// This value can be used with "protocole" or "desactivemoyenpaiement" parameters.
    /// </remarks>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
    [TypeConverter(typeof(EnumMemberConverter<PaymentProtocolEnum>))]
    public enum PaymentProtocolEnum
    {
        /// <summary>
        /// CB
        /// </summary>
        [EnumMember(Value = "CB")]
        CB = 0,
        /// <summary>
        /// Paypal
        /// </summary>
        [EnumMember(Value = "paypal")]
        PayPal,
        /// <summary>
        /// 3 x CB
        /// </summary>
        [EnumMember(Value = "1euro")]
        Cofidis1Euro,
        /// <summary>
        /// 3 x CB
        /// </summary>
        [EnumMember(Value = "3xcb")]
        Cofidis3xCB,
        /// <summary>
        /// 4 x CB
        /// </summary>
        [EnumMember(Value = "4xcb")]
        Cofidis4xCB,
        /// <summary>
        /// Lyfpay
        /// </summary>
        [EnumMember(Value = "lyfpay")]
        LyfPay,
        /// <summary>
        /// Sofort
        /// </summary>
        [EnumMember(Value = "sofort")]
        Sofort,
        /// <summary>
        /// Giropay
        /// </summary>
        [EnumMember(Value = "giropay")]
        Giropay,
    }
}
