namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Numéros des types de filtres bloquant le paiement (cf. tableau « Retours Module Prévention Fraude – détails »).
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
    /// <seealso href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
    public enum FiltrageCauseEnum
    {
        /// <summary>
        /// Adresse IP
        /// </summary>
        AdresseIP = 1,
        /// <summary>
        /// Numéro de carte
        /// </summary>
        NumeroCarte = 2,
        /// <summary>
        /// BIN de carte
        /// </summary>
        BinCarte = 3,
        /// <summary>
        /// Pays de la carte
        /// </summary>
        PaysCarte = 4,
        /// <summary>
        /// Pays de l’IP
        /// </summary>
        PaysIP = 5,
        /// <summary>
        /// Cohérence pays de la carte / pays de l’IP
        /// </summary>
        PaysCartePaysIP = 6,
        /// <summary>
        /// Email jetable
        /// </summary>
        EmailJetable = 7,
        /// <summary>
        /// Limitation en montant pour une CB sur une période donnée
        /// </summary>
        LimitationMontantParCB = 8,
        /// <summary>
        /// Limitation en nombre de transactions pour une CB sur une période donnée
        /// </summary>
        LimitationNombreTransactionsParCB = 9,
        /// <summary>
        /// Limitation en nombre de transactions par alias sur une période donnée
        /// </summary>
        LimitationNombreTransactionsParAlias = 11,
        /// <summary>
        /// Limitation en montant par alias sur une période donnée
        /// </summary>
        LimitationMontantParAlias = 12,
        /// <summary>
        /// Limitation en montant par IP sur une période donnée
        /// </summary>
        LimitationMontantParIP = 13,
        /// <summary>
        /// Limitation en nombre de transactions par IP sur une période donnée
        /// </summary>
        LimitationNombreTransactionsParIP = 14,
        /// <summary>
        /// Testeurs de cartes
        /// </summary>
        TesteursCartes = 15,
        /// <summary>
        /// Limitation en nombre d’alias par CB
        /// </summary>
        LimitationNombreAliasParCB = 16,
    }
}
