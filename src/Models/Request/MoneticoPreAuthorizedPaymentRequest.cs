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
    /// Represents a pre-authorized payment request to the Monetico Payment page.
    /// This object let you initialize a new pre-authorized payment request and allows you to retrieve
    /// all the HTML form fields to be included through the method <see cref="GetFormFields"/>.
    /// This class must be used only if your EPT is using pre-authorization payment mode. In other cases,
    /// use <see cref="MoneticoPaymentRequest"/> or <see cref="MoneticoSplitPaymentRequest"/>.
    /// </summary>
    public class MoneticoPreAuthorizedPaymentRequest : MoneticoPaymentRequest
    {
        /// <summary>
        /// Preauthorization dossier number
        /// </summary>
        public string NumeroDossier { get; private set; }

        /// <summary>
        /// Creates a new pre authorized payment request that targets the Monetico Payment page
        /// </summary>
        /// <param name="reference">Payment reference</param>
        /// <param name="montant">Payment amount</param>
        /// <param name="devise">Payment amount currency</param>
        /// <param name="language">Display language of the payment page</param>
        /// <param name="contexteCommande">Order context informations</param>
        /// <param name="numeroDossier">Preauthorization dossier number</param>
        public MoneticoPreAuthorizedPaymentRequest(MoneticoConfiguration configuration, string reference, decimal montant, CurrencyEnum devise, LanguageEnum language, OrderContext contexteCommande, string numeroDossier)
            : base(configuration, reference, montant, devise, language, contexteCommande)
        {
            // Please refer to technical documentation for full details about the format of each fields
            if (string.IsNullOrWhiteSpace(numeroDossier))
            {
                throw new ArgumentException("numeroDossier is mandatory", nameof(numeroDossier));
            }

            if (Regex.IsMatch(numeroDossier, "^[a-zA-Z0-9]{1, 12}$"))
            {
                throw new ArgumentException("numeroDossier must be alphabetical and cannot exceed 12 characters", nameof(numeroDossier));
            }

            NumeroDossier = numeroDossier;
        }

        public override IDictionary<string, string> GetFormFieldsWithoutMac()
        {
            IDictionary<string, string> formFields = base.GetFormFieldsWithoutMac();

            // Add pre authorisation specific fields
            formFields.Add("numero_dossier", NumeroDossier);

            return formFields;
        }
    }
}