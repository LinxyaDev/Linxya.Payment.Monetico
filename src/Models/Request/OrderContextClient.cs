using Linxya.Payment.Monetico.Converters;
using Newtonsoft.Json;

namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Informations client
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=96"/>
    public class OrderContextClient
    {
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
        /// Optionnelle
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
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        public string City { get; set; }
        /// <summary>
        /// Code postal
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 10 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        public string PostalCode { get; set; }
        /// <summary>
        /// Code pays
        /// Optionnelle
        /// Chaîne
        /// Norme ISO 3166-1 alpha-2 / case sensitive (majuscule)
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        public string Country { get; set; }
        /// <summary>
        /// Code géographique de l’état ou de la province (si applicable).
        /// Optionnelle
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
        /// Nom de naissance
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 45 caractères.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        public string BirthLastName { get; set; }
        /// <summary>
        /// Ville de naissance
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 50 caractères.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        public string BirthCity { get; set; }
        /// <summary>
        /// Code postal du lieu de naissance
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 10 caractères.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        public string BirthPostalCode { get; set; }
        /// <summary>
        /// Pays de naissance
        /// Optionnelle
        /// Chaîne
        /// Code pays sur 2 caractères suivant la norme ISO 3166-1 alpha-2
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        public string BirthCountry { get; set; }
        /// <summary>
        /// Optionnelle
        /// Chaîne
        /// Code géographique de l’état ou de la province de naissance (si applicable).
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        /// <seealso href="https://fr.wikipedia.org/wiki/ISO_3166-2:US"/>
        /// <seealso href="https://fr.wikipedia.org/wiki/ISO_3166-2:CA"/>
        public string BirthStateOrProvince { get; set; }
        /// <summary>
        /// Code géographique de l’entité du pays de naissance
        /// Optionnelle
        /// Chaîne
        /// Suivre la norme ISO 3166-2
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        /// <seealso href="https://en.wikipedia.org/wiki/ISO_3166-2"/>
        /// <seealso href="https://en.wikipedia.org/wiki/ISO_3166-2:FR"/>
        public string BirthCountrySubdivision { get; set; }
        /// <summary>
        /// Date de naissance
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        public DateTime? Birthdate { get; set; }
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
        /// Numéro d’une pièce d’identité.
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 255 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        public string NationalIDNumber { get; set; }
        /// <summary>
        /// Permet d’indiquer si des activités suspectes sur le compte du client on été relevées par le commerçant.
        /// Optionnelle
        /// Booléen
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=106"/>
        public bool SuspiciousAccountActivity { get; set; }
        /// <summary>
        /// Méthode d’authentification du client sur le site commerçant
        /// Optionnelle
        /// Chaîne
        /// Valeurs possibles :
        /// « guest » : pas d’authentification (invité)
        /// « own_credentials » : utilisation d’un compte ouvert sur le site commerçant
        /// « federated_id » : identité fédéré
        /// « issuer_credentials » : Identifiants fournis par l’émetteur
        /// « third_party_authentication » : authentification par un tiers
        /// « fido » : utilisation de l’authentification FIDO
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string AuthenticationMethod { get; set; }
        /// <summary>
        /// Date et heure UTC de l’authentification du client sur le site commerçant.
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJTHH:mm:SSZ avec AAAA = année sur 4 chiffres,
        ///  MM = mois sur 2 chiffres, JJ = jour sur deux chiffres, HH = heure sur 2 chiffres, mm = minutes sur 2 chiffres, SS = secondes sur deux chiffres(ISO 8601)
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=98"/>
        [JsonConverter(typeof(Iso8601FullDateTimeJsonConverter))]
        public DateTime? AuthenticationTimestamp { get; set; }
        /// <summary>
        /// Mécanisme utilisé pour l’authentification du porteur lors de son dernier paiement sur le site commerçant.
        /// Optionnelle
        /// Chaîne
        /// Valeurs possibles :
        /// « frictionless » : L’ACS a permis un paiement sans challenge
        /// « challenge » : Le porteur a dû compléter l’étape du challenge
        /// « AVS_verified » : Vérification de l’adresse du porteur(système AVS)
        /// « other » : Autre méthode d’authentification
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        public string PriorAuthenticationMethod { get; set; }
        /// <summary>
        /// Date et heure UTC de la précédente authentification du client sur le site commerçant.
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJTHH:mm:SSZ avec AAAA = année sur 4 chiffres,
        ///  MM = mois sur 2 chiffres, JJ = jour sur deux chiffres, HH = heure sur 2 chiffres, mm = minutes sur 2 chiffres, SS = secondes sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        [JsonConverter(typeof(Iso8601FullDateTimeJsonConverter))]
        public DateTime? PriorAuthenticationTimestamp { get; set; }
        /// <summary>
        /// Date à laquelle la carte a été ajoutée sur le compte du client (sur le site commerçant).
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=103"/>
        public DateTime? PaymentMeanAge { get; set; }
        /// <summary>
        /// Nombre de transactions (achevées ou abandonnées) du client avec n’importe quel moyen de paiement enregistrés sur le site commerçant durant la dernière année.
        /// Optionnelle
        /// Entier positif ou nul
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=102"/>
        public int LastYearTransactions { get; set; }
        /// <summary>
        /// Nombre de transactions (achevées ou abandonnées) du client avec n’importe quel moyen de paiement enregistrés sur le site commerçant durant les 24 dernières heures.
        /// Optionnelle
        /// Entier positif ou nul
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=101"/>
        public int Last24HoursTransactions { get; set; }
        /// <summary>
        /// Nombre de tentatives d’ajout carte du client sur le site commerçant durant les 24 dernières heures.
        /// Optionnelle
        /// Entier
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public int AddCardNbLast24Hours { get; set; }
        /// <summary>
        /// Nombre d’achats avec ce moyen de paiement les 6 derniers mois.
        /// Optionnelle
        /// Entier positif ou nul
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=101"/>
        public int Last6MonthsPurchase { get; set; }
        /// <summary>
        /// Date à laquelle le client a changé son mot de passe ou réinitialisé son compte pour la dernière fois.
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=102"/>
        public DateTime? LastPasswordChange { get; set; }
        /// <summary>
        /// Date de création du compte client sur le site commerçant.
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public DateTime? AccountAge { get; set; }
        /// <summary>
        /// Date de la dernière modification du compte client (y compris nouvelle adresse de facturation, nouvelle adresse de livraison, nouveau moyen de paiement enregistré).
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=102"/>
        public DateTime? LastAccountModification { get; set; }
    }
}