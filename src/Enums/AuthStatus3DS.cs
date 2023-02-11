namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Indicateur d’échange 3DSecure 1.X
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=111"/>
    public enum AuthStatus3DS
    {
        /// <summary>
        /// La transaction ne s’est pas faite selon le protocole 3DSecure et le risque d’impayé est élevé
        /// </summary>
        PasDeTransactionRisqueImpayeEleve = -1,
        /// <summary>
        /// La transaction s’est faite selon le protocole 3DS et le risque d’impayé est faible
        /// </summary>
        TransactionRisqueImpayeFaible = 1,
        /// <summary>
        /// La transaction s’est faite selon le protocole 3DS et le risque d’impayé est élevé
        /// </summary>
        TransactionRisqueImpayeEleve = 4,
    }
}
