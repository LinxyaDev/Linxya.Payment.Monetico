namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Represents the "contexte_commande" field content.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=93"/>
    public class OrderContext
    {
        public OrderContext(OrderContextBilling billing)
        {
            Billing = billing;
        }
        /// <summary>
        /// Adresse de facturation
        /// Obligatoire
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=94"/>
        public OrderContextBilling Billing { get; private set; }

        /// <summary>
        /// Adresse de livraison
        /// Obligatoire si applicable
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=94"/>
        public OrderContextShipping Shipping { get; set; }

        /// <summary>
        /// Panier client
        /// Optionnelle
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=95"/>
        public OrderContextShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Informations client
        /// Optionnelle
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=96"/>
        public OrderContextClient Client { get; set; }
    }
}