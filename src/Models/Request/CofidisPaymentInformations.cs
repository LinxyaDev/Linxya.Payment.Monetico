using Linxya.Payment.Monetico.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Represents additional <see cref="MoneticoPaymentRequest"/> informations that are specific to the COFIDIS partner.
    /// These values can be used only if your EPT has a COFIDIS payment mean activated (1euro, 3xCB, ...).
    /// You can use this to pre fill the request form on the COFIDIS website.
    /// </summary>
    public class CofidisPaymentInformations
    {
        /// <summary>
        /// Civility of the customer
        /// </summary>
        public CofidisCivilityEnum? CiviliteClient { get; set; }

        /// <summary>
        /// Last name of the customer
        /// </summary>
        public string NomClient { get; set; }

        /// <summary>
        /// First name of the customer
        /// </summary>
        public string PrenomClient { get; set; }

        /// <summary>
        /// Address of the customer
        /// </summary>
        public string AdresseClient { get; set; }

        /// <summary>
        /// Additional address informations of the customer
        /// </summary>
        public string ComplementAdresseClient { get; set; }

        /// <summary>
        /// Zip code of the customer
        /// </summary>
        public string CodePostalClient { get; set; }

        /// <summary>
        /// City of the customer
        /// </summary>
        public string VilleClient { get; set; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        public string PaysClient { get; set; }

        /// <summary>
        /// Landline phone of the customer
        /// </summary>
        public string TelephoneFixeClient { get; set; }

        /// <summary>
        /// Mobile phone of the customer
        /// </summary>
        public string TelephoneMobileClient { get; set; }

        /// <summary>
        /// Customer’s geographic code of the entity of the country of birth
        /// </summary>
        public string DepartementNaissanceClient { get; set; }

        /// <summary>
        /// Birthdate of the customer
        /// </summary>
        public DateTime? DateNaissanceClient { get; set; }

        /// <summary>
        /// Cofidis pre-scoring
        /// </summary>
        public int? PreScore { get; set; }

        public IDictionary<string, string> GetFormFields()
        {
            IDictionary<string, string> formFields = new Dictionary<string, string>();

            // For most of the fields, the value can be provided as is
            if (CiviliteClient.HasValue)
            {
                formFields.Add("civiliteclient", Enum.GetName(typeof(CofidisCivilityEnum), CiviliteClient.Value));
            }

            if (!string.IsNullOrEmpty(NomClient))
            {
                formFields.Add("nomclient", NomClient);
            }

            if (!string.IsNullOrEmpty(PrenomClient))
            {
                formFields.Add("prenomclient", PrenomClient);
            }

            if (!string.IsNullOrEmpty(AdresseClient))
            {
                formFields.Add("adresseclient", AdresseClient);
            }

            if (!string.IsNullOrEmpty(ComplementAdresseClient))
            {
                formFields.Add("complementadresseclient", ComplementAdresseClient);
            }

            if (!string.IsNullOrEmpty(CodePostalClient))
            {
                formFields.Add("codepostalclient", CodePostalClient);
            }

            if (!string.IsNullOrEmpty(VilleClient))
            {
                formFields.Add("villeclient", VilleClient);
            }

            if (!string.IsNullOrEmpty(PaysClient))
            {
                formFields.Add("paysclient", PaysClient);
            }

            if (!string.IsNullOrEmpty(TelephoneFixeClient))
            {
                formFields.Add("telephonefixeclient", TelephoneFixeClient);
            }

            if (!string.IsNullOrEmpty(TelephoneMobileClient))
            {
                formFields.Add("telephonemobileclient", TelephoneMobileClient);
            }

            if (!string.IsNullOrEmpty(DepartementNaissanceClient))
            {
                formFields.Add("departementnaissanceclient", DepartementNaissanceClient);
            }

            if (DateNaissanceClient.HasValue)
            {
                formFields.Add("datenaissanceclient", DateNaissanceClient.Value.ToString("yyyyMMdd"));
            }

            if (PreScore.HasValue)
            {
                formFields.Add("prescore", PreScore.Value.ToString());
            }

            // All COFIDIS fields values must be encoded in hexadecimal (see technical documentation)
            formFields = formFields.ToDictionary(f => f.Key, f => HexadecimalHelper.ToHexadecimalRepresentation(f.Value));

            return formFields;
        }
    }
}