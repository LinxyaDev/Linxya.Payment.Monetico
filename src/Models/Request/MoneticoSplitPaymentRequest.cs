using Linxya.Payment.Monetico.Enums;
using Linxya.Payment.Monetico.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Represents a split payment request to the Monetico Payment page.
    /// This object let you initialize a new pre-authorized payment request and allows you to retrieve
    /// all the HTML form fields to be included through the method <see cref="GetFormFields"/>.
    /// This class must only be used if your EPT is using split payment mode. In other cases,
    /// use <see cref="MoneticoPaymentRequest"/> or <see cref="MoneticoPreAuthorizedPaymentRequest"/> instead.
    /// </summary>
    public class MoneticoSplitPaymentRequest : MoneticoPaymentRequest
    {
        /// <summary>
        /// Numbers of instalments (2, 3 or 4) this payment will be divided into
        /// </summary>
        public int? NbrEch { get; set; }

        /// <summary>
        /// Date of the first instalment
        /// The first instalment MUST be set to today's date
        /// </summary>
        public DateTime? DateEch1 { get; set; }

        /// <summary>
        /// Date of the second instalment
        /// </summary>
        public DateTime? DateEch2 { get; set; }

        /// <summary>
        /// Date of the third instalment
        /// </summary>
        public DateTime? DateEch3 { get; set; }

        /// <summary>
        /// Date of the fourth instalment
        /// </summary>
        public DateTime? DateEch4 { get; set; }

        /// <summary>
        /// Amount of the first instalment
        /// </summary>
        public decimal? MontantEch1 { get; set; }

        /// <summary>
        /// Amount of the second instalment
        /// </summary>
        public decimal? MontantEch2 { get; set; }

        /// <summary>
        /// Amount of the third instalment
        /// </summary>
        public decimal? MontantEch3 { get; set; }

        /// <summary>
        /// Amount of the fourth instalment
        /// </summary>
        public decimal? MontantEch4 { get; set; }

        /// <summary>
        /// Creates a new split payment request that targets the Monetico Payment page
        /// </summary>
        /// <param name="reference">Payment reference</param>
        /// <param name="montant">Payment amount</param>
        /// <param name="devise">Payment amount currency</param>
        /// <param name="language">Display language of the payment page</param>
        /// <param name="contexteCommande">Order context informations</param>
        public MoneticoSplitPaymentRequest(MoneticoConfiguration configuration, string reference, decimal montant, CurrencyEnum devise, LanguageEnum language, OrderContext contexteCommande)
            : base(configuration, reference, montant, devise, language, contexteCommande)
        {
        }

        public override IDictionary<string, string> GetFormFieldsWithoutMac()
        {
            IDictionary<string, string> formFields = base.GetFormFieldsWithoutMac();

            // Add split payment specific fields
            const string dateFormat = "dd/MM/yyyy";
            if (NbrEch.HasValue)
            {
                formFields.Add("nbrech", NbrEch.Value.ToString());
            }

            if (DateEch1.HasValue)
            {
                formFields.Add("dateech1", DateEch1.Value.ToString(dateFormat));
            }

            if (DateEch2.HasValue)
            {
                formFields.Add("dateech2", DateEch2.Value.ToString(dateFormat));
            }

            if (DateEch3.HasValue)
            {
                formFields.Add("dateech3", DateEch3.Value.ToString(dateFormat));
            }

            if (DateEch4.HasValue)
            {
                formFields.Add("dateech4", DateEch4.Value.ToString(dateFormat));
            }

            if (MontantEch1.HasValue)
            {
                formFields.Add("montantech1", FormatAmount(MontantEch1.Value, Devise));
            }

            if (MontantEch2.HasValue)
            {
                formFields.Add("montantech2", FormatAmount(MontantEch2.Value, Devise));
            }

            if (MontantEch3.HasValue)
            {
                formFields.Add("montantech3", FormatAmount(MontantEch3.Value, Devise));
            }

            if (MontantEch4.HasValue)
            {
                formFields.Add("montantech4", FormatAmount(MontantEch4.Value, Devise));
            }

            return formFields;
        }
    }
}