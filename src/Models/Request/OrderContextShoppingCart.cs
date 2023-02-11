namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Panier client
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=95"/>
    public class OrderContextShoppingCart
    {
        /// <summary>
        /// Montant utilisé pour l’achat de cartes / codes cadeaux, exprimé dans la plus petite unité de la monnaie.
        /// Optionnelle
        /// Nombre entier
        /// Maximum de 12 chiffres utiles
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=100"/>
        public int GiftCardAmount { get; set; }
        /// <summary>
        /// Nombre de cartes cadeaux achetées
        /// Optionnelle
        /// Nombre entier
        /// Maximum de 2 chiffres utiles
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=101"/>
        public int GiftCardCount { get; set; }
        /// <summary>
        /// Devise de la carte cadeaux achetée
        /// Optionnelle
        /// Chaîne
        /// 3 caractères alphabétiques. Norme ISO 4217
        /// </summary>
        /// <example>
        /// EUR
        /// </example>
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=101"/>
        public string GiftCardCurrency { get; set; }
        /// <summary>
        /// Pour une précommande, date à laquelle la marchandise sera disponible.
        /// Optionnelle
        /// Convertie en chaîne, au format ISO 8601
        /// Du type AAAA-MM-JJ avec AAAA = année sur 4 chiffres, MM = mois sur 2 chiffres, JJ = jour sur deux chiffres
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        public DateTime? PreOrderDate { get; set; }
        /// <summary>
        /// Indique s’il s’agit d’une précommande.
        /// Optionnelle
        /// Boolééen
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=104"/>
        public bool PreorderIndicator { get; set; }
        /// <summary>
        /// Vaut « true » si et seulement si le client a déjà passé une commande identique.
        /// Optionnelle
        /// Boolééen
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=105"/>
        public bool ReorderIndicator { get; set; }
        /// <summary>
        /// Articles du panier client
        /// Si l’objet « shoppingCart » est envoyé, dans ce cas, certains champs doivent obligatoirement être renseignés dans l’objet « shoppingCartItems ».
        /// Optionnelle
        /// Tableau d'objets
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=95"/>
        public IEnumerable<OrderContextShoppingCartItem> ShoppingCartItems { get; set; }
    }
}