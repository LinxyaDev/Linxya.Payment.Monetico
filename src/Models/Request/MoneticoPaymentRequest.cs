using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Linxya.Payment.Monetico.Enums;
using Linxya.Payment.Monetico.Extensions;
using Linxya.Payment.Monetico.Models.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PhoneNumbers;

namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Represents a payment request to the Monetico Payment page.
    /// This object let you initialize a new payment request and allows you to retrieve all the HTML form
    /// fields to be included through the method <see cref="GetFormFields"/>.
    /// If you are using an EPT with split payment mode, use <see cref="MoneticoSplitPaymentRequest"/> instead.
    /// </summary>
    /// <example>
    /// <code>
    /// PaymentRequest payment = new PaymentRequest(
    ///     "reference",
    ///     1,
    ///     PaymentRequest.Currency.EUR,
    ///     PaymentRequest.Languages.FR,
    ///     new OrderContext(new OrderContextBilling("address", "city", "postalCode", "country"))
    /// );
    ///
    /// // The following dictionary contains all the fields to include
    /// // in your HTML form including the calculated seal
    /// IDictionary&lt;string, string&gt; fields = payment.GetFormFields();
    /// </code>
    /// </example>
    public class MoneticoPaymentRequest
    {
        /// <summary>
        /// Reference of the payment
        /// </summary>
        public string Reference { get; private set; }

        /// <summary>
        /// Date of the payment
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Amount of the payment
        /// </summary>
        public decimal Montant { get; private set; }

        /// <summary>
        /// Currency of the payment
        /// </summary>
        public CurrencyEnum Devise { get; private set; }

        /// <summary>
        /// Display language of the payment page
        /// </summary>
        public LanguageEnum Langue { get; private set; }

        /// <summary>
        /// Order context
        /// </summary>
        public OrderContext ContexteCommande { get; private set; }

        /// <summary>
        /// Free text associated with this payment.
        /// Free text allows you to associate any text that you wish to see on your dashboard when viewing this payment.
        /// </summary>
        /// <remarks>
        /// The content of this field may be blocked for security reasons.
        /// Therefore, it is recommended to avoid special characters and line feeds.
        /// </remarks>
        public string TexteLibre { get; set; }

        /// <summary>
        /// Client e-mail address
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// URL of the page that will be used by Monetico payment page to redirect the client if the payment has been done successfully
        /// </summary>
        public Uri UrlRetourOk { get; set; }

        /// <summary>
        /// URL of the page that will be used by Monetico payment page to redirect the client if the payment has failed
        /// </summary>
        public Uri UrlRetourErreur { get; set; }

        /// <summary>
        /// Indicates if the merchant wish not to authenticate the client (optional parameter)
        /// </summary>
        public bool? TDSDebrayable { get; set; }

        /// <summary>
        /// Indicates the merchant wish about client authentication in 3DSecure V2 protocol (optional parameter)
        /// </summary>
        public AuthThreeDSecurePreference? ThreeDSecureChallenge { get; set; }

        /// <summary>
        /// Label that will appear on the card holder's bank statement (optional parameter)
        /// </summary>
        public string LibelleMonetique { get; set; }

        /// <summary>
        /// Location/city that will appear on the card holder's bank statement (optional parameter)
        /// </summary>
        public string LibelleMoneticoLocalite { get; set; }

        /// <summary>
        /// Indicates the alternate payment mode that the payment page must not display for this payment (optional parameter)
        /// </summary>
        public IEnumerable<PaymentProtocolEnum> DesactiveMoyenPaiement { get; set; }

        /// <summary>
        /// Alias of the client bank card to use (optional parameter) (requires subscription to the "express payment" option)
        /// </summary>
        public string AliasCb { get; set; }

        /// <summary>
        /// Forces the client to input a bank card (optional parameter) (requires subscription to the "express payment" option)
        /// </summary>
        public bool? ForceSaisieCb { get; set; }

        /// <summary>
        /// Indicates to the payment page that this payment has to be proceed using selected protocol.
        /// The client will be immediately redirected to the partner protocol page and will not see the Monetico payment page itself.
        /// (optional parameter) (requires subscription to a partner payment protocol)
        /// </summary>
        public PaymentProtocolEnum? Protocole { get; set; }

        /// <summary>
        /// Fields specific to Cofidis allowing to pre fill the request form on Cofidis site
        /// </summary>
        public CofidisPaymentInformations Cofidis { get; set; }

        private readonly MoneticoConfiguration _configuration;

        /// <summary>
        /// Creates a new payment request that targets the Monetico Payment page
        /// </summary>
        /// <param name="reference">Payment reference</param>
        /// <param name="montant">Payment amount</param>
        /// <param name="devise">Payment amount currency</param>
        /// <param name="language">Display language of the payment page</param>
        /// <param name="contexteCommande">Order context informations</param>
        public MoneticoPaymentRequest(MoneticoConfiguration configuration, string reference, decimal montant, string devise, string language, OrderContext contexteCommande)
            : this(
                  configuration,
                  reference,
                  montant,
                  Enum.TryParse<CurrencyEnum>(devise, out var deviseEnum) ? deviseEnum : CurrencyEnum.EUR,
                  Enum.TryParse<LanguageEnum>(devise, out var languageEnum) ? languageEnum : LanguageEnum.FR,
                  contexteCommande
                  )
        {
        }
        /// <summary>
        /// Creates a new payment request that targets the Monetico Payment page
        /// </summary>
        /// <param name="reference">Payment reference</param>
        /// <param name="montant">Payment amount</param>
        /// <param name="devise">Payment amount currency</param>
        /// <param name="language">Display language of the payment page</param>
        /// <param name="contexteCommande">Order context informations</param>
        public MoneticoPaymentRequest(MoneticoConfiguration configuration, string reference, decimal montant, CurrencyEnum devise, LanguageEnum language, OrderContext contexteCommande)
        {
            _configuration = configuration;
            if (string.IsNullOrWhiteSpace(reference))
            {
                throw new ArgumentException("Parameter is mandatory", nameof(reference));
            }

            if (montant <= 0)
            {
                throw new ArgumentException("Parameter must be strictly positive", nameof(montant));
            }

            if (contexteCommande == null)
            {
                throw new ArgumentNullException(nameof(contexteCommande));
            }

            Reference = reference;
            Montant = montant;
            Devise = devise;
            ContexteCommande = contexteCommande;
            Date = DateTime.Now;
            Langue = language;

            ValidateContextValues();
        }

        private void ValidateContextValues()
        {
            if (ContexteCommande?.Client?.Phone != null)
            {
                ContexteCommande.Client.Phone = GetFormatedPhoneNumber(ContexteCommande.Client.Phone, Langue);
            }
            if (ContexteCommande?.Billing?.Phone != null)
            {
                ContexteCommande.Billing.Phone = GetFormatedPhoneNumber(ContexteCommande.Billing.Phone, Langue);
            }
            if (ContexteCommande?.Shipping?.Phone != null)
            {
                ContexteCommande.Shipping.Phone = GetFormatedPhoneNumber(ContexteCommande.Shipping.Phone, Langue);
            }
            if (ContexteCommande?.Client?.Civility != null)
            {
                ContexteCommande.Client.Civility = ContexteCommande.Client.Civility.Replace(".", "");
            }
            if (ContexteCommande?.Billing?.Civility != null)
            {
                ContexteCommande.Billing.Civility = ContexteCommande.Billing.Civility.Replace(".", "");
            }
            if (ContexteCommande?.Shipping?.Civility != null)
            {
                ContexteCommande.Shipping.Civility = ContexteCommande.Shipping.Civility.Replace(".", "");
            }
        }

        private static string GetFormatedPhoneNumber(string originalPhone, LanguageEnum language)
        {
            string newPhone = originalPhone;
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                newPhone = phoneNumberUtil
                    .Format(phoneNumberUtil.Parse(originalPhone, Enum.GetName(typeof(LanguageEnum), language)), PhoneNumberFormat.INTERNATIONAL)
                    .ReplaceFirstOccurrence(" ", "-")
                    .Replace(" ", "");
            }
            catch (Exception) { }
            return newPhone;
        }

        /// <summary>
        /// Return the form fields to send to the payment page for this payment.
        /// This does not include the MAC parameter with the result of the sealing.
        /// The purpose of this method is to allow the addition of specific fields for specific cases
        /// like split payment, pre-authorisation payment, and so on. See the derived classes for example.
        /// To build the form with all required parameters to call the Monetico Payment page, use <see cref="GetFormFields"/>
        /// </summary>
        /// <returns>Form fields to sent to the payment page (not including the MAC parameter)</returns>
        /// <remarks>
        /// This method should be protected.
        /// It is public only to be able to display the seal string used on the example page.
        /// </remarks>
        public virtual IDictionary<string, string> GetFormFieldsWithoutMac()
        {
            // All parameters defined below are described in details in the Monetico technical documentation
            // including their respective format. Please see this documentation for details.
            IDictionary<string, string> formFields = new Dictionary<string, string>();

            // Payment terminal
            formFields.Add("TPE", _configuration.Tpe);
            formFields.Add("societe", _configuration.SocietyCode);
            formFields.Add("lgue", Enum.GetName(typeof(LanguageEnum), Langue));
            formFields.Add("version", string.IsNullOrWhiteSpace(_configuration.Version) ? "3.0" : _configuration.Version);

            // Payment informations
            formFields.Add("reference", Reference);
            formFields.Add("date", Date.ToString("dd/MM/yyyy:HH:mm:ss"));
            formFields.Add("montant", FormatAmount(Montant, Devise));
            formFields.Add("contexte_commande", Convert.ToBase64String(Encoding.UTF8.GetBytes(SerializeAsJson(ContexteCommande))));

            // Optional parameters
            if (!string.IsNullOrEmpty(TexteLibre))
            {
                formFields.Add("texte-libre", TexteLibre);
            }

            if (!string.IsNullOrEmpty(Mail))
            {
                formFields.Add("mail", Mail);
            }

            if (UrlRetourOk != null)
            {
                formFields.Add("url_retour_ok", UrlRetourOk.ToString());
            }

            if (UrlRetourErreur != null)
            {
                formFields.Add("url_retour_err", UrlRetourErreur.ToString());
            }

            if (TDSDebrayable.HasValue)
            {
                formFields.Add("3dsdebrayable", TDSDebrayable.Value ? "1" : "0");
            }

            if (ThreeDSecureChallenge.HasValue)
            {
                formFields.Add("ThreeDSecureChallenge", ThreeDSecureChallenge.Value.ToEnumString());
            }

            if (!string.IsNullOrEmpty(LibelleMonetique))
            {
                formFields.Add("libelleMonetique", LibelleMonetique);
            }

            if (!string.IsNullOrEmpty(LibelleMoneticoLocalite))
            {
                formFields.Add("libelleMonetiqueLocalite", LibelleMoneticoLocalite);
            }

            if (DesactiveMoyenPaiement != null && DesactiveMoyenPaiement.Any())
            {
                formFields.Add("desactivemoyenpaiement", string.Join(",", DesactiveMoyenPaiement.Select(m => m.ToEnumString())));
            }

            if (!string.IsNullOrEmpty(AliasCb))
            {
                formFields.Add("aliascb", AliasCb);
            }

            if (ForceSaisieCb.HasValue)
            {
                formFields.Add("forcesaisiecb", ForceSaisieCb.Value ? "1" : "0");
            }

            if (Protocole.HasValue)
            {
                formFields.Add("protocole", Protocole.Value.ToEnumString());
            }

            // Cofidis partner optional fields
            if (Cofidis != null)
            {
                IDictionary<string, string> cofidisFields = Cofidis.GetFormFields();
                if (cofidisFields.Any())
                {
                    cofidisFields.ToList().ForEach(f => formFields.Add(f.Key, f.Value));
                }
            }

            return formFields;
        }

        protected string FormatAmount(decimal amount, CurrencyEnum currency)
        {
            return amount.ToString("F2", CultureInfo.InvariantCulture) + Enum.GetName(typeof(CurrencyEnum), currency);
        }

        /// <summary>
        /// Serializes given object in JSON with respect to the Monetico Payment expectations
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON representation of <paramref name="obj"/></returns>
        /// <remarks>
        /// This method is made public only to show the JSON representation of some parameters in
        /// the example page.
        /// </remarks>
        public string SerializeAsJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                DateFormatString = "yyyy-MM-dd",
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        /// <summary>
        /// Returns all the form fields that have to be posted to the Monetico Payment page.
        /// This includes the MAC field with the result of the sealing.
        /// You should call the Monetico Payment page with all the required parameters, only the optional parameters
        /// you want to used and nothing else. Do not send form fields that are not defined in the technical documentation.
        /// </summary>
        /// <returns>Form fields that have to be sent to the Monetico Payment page</returns>
        public IDictionary<string, string> GetFormFields()
        {
            IDictionary<string, string> formFields = GetFormFieldsWithoutMac();

            // The MAC field value is computed by taking into account all the fields
            // sent to the payment page. Therefore, it must be done once all other
            // fields have been defined.
            string sealValue = new HmacComputer().SealFields(formFields, _configuration.MacKey);
            formFields.Add("MAC", sealValue);

            return formFields;
        }
    }
}