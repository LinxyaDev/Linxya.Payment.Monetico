namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Indique le statut de débrayage de l’authentification du porteur.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
    public enum StatutDebrayageAuthentificationEnum
    {
        /// <summary>
        /// Débrayage non demandé
        /// </summary>
        DebrayageNonDemande = 0,
        /// <summary>
        /// Débrayage accordé
        /// </summary>
        DebrayageAccorde = 1,
        /// <summary>
        /// Débrayage non accordé en raison du type de carte de paiement
        /// </summary>
        DebrayagNonAccordeTypePaiement = -1,
        /// <summary>
        /// Débrayage non accordé en raison des options du paiement
        /// </summary>
        DebrayageNonAccordeOptionsPaiement = -2,
    }
}
