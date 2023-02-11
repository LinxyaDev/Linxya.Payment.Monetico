namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Adresse de facturation
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=94"/>
    public class OrderContextBilling
    {
        public OrderContextBilling(string addressLine1, string city, string postalCode, string country)
        {
            AddressLine1 = addressLine1;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
        /// <summary>
        /// Civilité
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 32 caractères alphabétiques.
        /// Pas de ponctuation.
        /// </summary>
        /// <example>
        /// « M », « Mme »
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        public string Civility { get; set; }
        /// <summary>
        /// Nom et prénom
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 45 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        public string Name { get; set; }
        /// <summary>
        /// Prénom
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 45 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=100"/>
        public string FirstName { get; set; }
        /// <summary>
        /// Nom de famille
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 45 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=102"/>
        public string LastName { get; set; }
        /// <summary>
        /// Deuxième prénom (et suivants)
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 150 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=102"/>
        public string MiddleName { get; set; }
        /// <summary>
        /// Adresse complète du client (numéro, rue, complément)
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 255 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string Address { get; set; }
        /// <summary>
        /// Contient le numéro et le nom de la rue
        /// Obligatoire
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Contient le numéro et le nom de la rue
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Toute information complémentaire d’adresse ne pouvant figurer dans les lignes 1 et 2 de l’adresse.
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string AddressLine3 { get; set; }
        /// <summary>
        /// Ville, peut contenir le CEDEX.
        /// Obligatoire
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        public string City { get; set; }
        /// <summary>
        /// Code postal
        /// Obligatoire
        /// Chaîne
        /// Jusqu’à 10 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        public string PostalCode { get; set; }
        /// <summary>
        /// Code pays
        /// Obligatoire
        /// Chaîne
        /// Norme ISO 3166-1 alpha-2 / case sensitive (majuscule)
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        public string Country { get; set; }
        /// <summary>
        /// Code géographique de l’état ou de la province (si applicable).
        /// Obligatoire si applicable
        /// Chaîne
        /// ISO 3166-2
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=106"/>
        /// <seealso href="https://fr.wikipedia.org/wiki/ISO_3166-2:US"/>
        /// <seealso href="https://fr.wikipedia.org/wiki/ISO_3166-2:CA"/>
        public string StateOrProvince { get; set; }
        /// <summary>
        /// Code géographique de l’entité du pays
        /// Optionnelle
        /// Chaîne
        /// ISO 3166-2
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        /// <seealso href="https://en.wikipedia.org/wiki/ISO_3166-2"/>
        /// <seealso href="https://en.wikipedia.org/wiki/ISO_3166-2:FR"/>
        public string CountrySubdivision { get; set; }
        /// <summary>
        /// Courriel
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 254 caractères. Vérifie l’expression régulière « ^.+@.+\..+$ ».
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=100"/>
        public string Email { get; set; }
        /// <summary>
        /// Numéro de téléphone
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 18 caractères numériques avec « + » comme premier caractère, suivi de l’indicatif pays, d’un tiret « - », puis du numéro
        /// </summary>
        /// <example>
        /// Le numéro français 06 12 34 56 78 s’écrira « +33-612345678 »
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        /// <seealso href="https://en.wikipedia.org/wiki/List_of_country_calling_codes"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.123"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.164"/>
        public string Phone { get; set; }
        /// <summary>
        /// Numéro de téléphone portable
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 18 caractères numériques avec « + » comme premier caractère, suivi de l’indicatif pays, d’un tiret « - », puis du numéro
        /// </summary>
        /// <example>
        /// Le numéro français 06 12 34 56 78 s’écrira « +33-612345678 »
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        /// <seealso href="https://en.wikipedia.org/wiki/List_of_country_calling_codes"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.123"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.164"/>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Numéro de téléphone
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 18 caractères numériques avec « + » comme premier caractère, suivi de l’indicatif pays, d’un tiret « - », puis du numéro
        /// </summary>
        /// <example>
        /// Le numéro français 06 12 34 56 78 s’écrira « +33-612345678 »
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        /// <seealso href="https://en.wikipedia.org/wiki/List_of_country_calling_codes"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.123"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.164"/>
        public string HomePhone { get; set; }
        /// <summary>
        /// Numéro de téléphone professionnel
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 18 caractères numériques avec « + » comme premier caractère, suivi de l’indicatif pays, d’un tiret « - », puis du numéro
        /// </summary>
        /// <example>
        /// Le numéro français 06 12 34 56 78 s’écrira « +33-612345678 »
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        /// <seealso href="https://en.wikipedia.org/wiki/List_of_country_calling_codes"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.123"/>
        /// <seealso href="https://en.wikipedia.org/wiki/E.164"/>
        public string WorkPhone { get; set; }

    }
}