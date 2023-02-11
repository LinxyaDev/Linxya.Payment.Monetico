namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Adresse de livraison
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=94"/>
    public class OrderContextShipping
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
        /// Adresse complète du client (numéro, rue, complément)
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 255 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string Address { get; set; }
        /// <summary>
        /// Contient le numéro et le nom de la rue
        /// Obligatoire si applicable
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=97"/>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Contient le numéro et le nom de la rue
        /// Obligatoire si applicable
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
        /// Obligatoire si applicable
        /// Chaîne
        /// Jusqu’à 50 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=99"/>
        public string City { get; set; }
        /// <summary>
        /// Code postal
        /// Obligatoire si applicable
        /// Chaîne
        /// Jusqu’à 10 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        public string PostalCode { get; set; }
        /// <summary>
        /// Code pays
        /// Obligatoire si applicable
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
        /// Moyen d’expédition retenu.
        /// Optionnelle
        /// Chaîne
        /// Valeurs possibles :
        /// « digital_goods »: Biens numériques (pas d’expédition).
        /// « travel_and_event »: Transports ou évènements(pas d’expédition).
        /// « billing_address »: Expédition sur l’adresse de facturation.
        /// « verified_address »: Expédition vers une adresse déjà utilisée.
        /// « another_address »: Expédition vers une nouvelle adresse.
        /// « pick-up » : Expédition vers un point relai.
        /// « other » Autre.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=106"/>
        public string ShipIndicator { get; set; }
        /// <summary>
        /// Indique le délai d’expédition de la commande.
        /// Optionnelle
        /// Chaîne
        /// Valeurs possibles :
        /// « same_day » : le jour même
        /// « overnight » : le lendemain
        /// « two_day » : deux jours
        /// « three_day » : trois jours
        /// « long » : plus de trois jours
        /// « other » : autre
        /// « none » : pas d’expédition
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=100"/>
        public string DeliveryTimeframe { get; set; }
        /// <summary>
        /// Date à laquelle l’adresse d’expédition a été utilisée pour la première fois.
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=100"/>
        public DateTime? FirstUseDate { get; set; }
        /// <summary>
        /// Indique si les adresses d’expédition ou de facturation sont identiques.
        /// Optionnelle
        /// Booléen
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=102"/>
        public bool MatchBillingAddress { get; set; }
    }
}