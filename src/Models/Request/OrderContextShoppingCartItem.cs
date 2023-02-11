namespace Linxya.Payment.Monetico.Models.Request
{
    /// <summary>
    /// Article du panier client
    /// Si l’objet « shoppingCart » est envoyé, dans ce cas, certains champs doivent obligatoirement être renseignés dans l’objet « shoppingCartItems ».
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=95"/>
    public class OrderContextShoppingCartItem
    {
        /// <summary>
        /// Nom
        /// Optionnelle
        /// Chaîne
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description d’un article.
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 2048 caractères.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=100"/>
        public string Description { get; set; }
        /// <summary>
        /// Indique le type de produit.
        /// Optionnelle
        /// Chaîne
        /// Valeurs possibles :
        /// « adult_content » : contenu pour adulte
        /// « coupon » : bon de reduction appliqué à la commande
        /// « default » : valeur par défaut(si aucun autre code ne convient)
        /// « electronic_good » : biens éléctroniques(pas de logiciels)
        /// « electronic_software » : logiciels
        /// « gift_certificate » : cheque-cadeau
        /// « handling_only » : frais administratifs
        /// « service » : service rendu au client
        /// « shipping_and_handling » : frais d’expédition et administratifs
        /// « shipping_only » : frais d’expédition uniquement
        /// « subscription » : abonnement à un site web ou autre
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=105"/>
        public string ProductCode { get; set; }
        /// <summary>
        /// URL pointant vers une image associée à un article.
        /// Optionnelle
        /// Chaîne
        /// Jusqu’à 2000 caractères.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=101"/>
        public string ImageURL { get; set; }
        /// <summary>
        /// Montant exprimé dans la plus petite unité de la monnaie (par exemple en centimes pour le cas de l’EURO)
        /// Obligatoire
        /// Nombre entier
        /// Maximum de 12 chiffres utiles
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=106"/>
        public int UnitPrice { get; set; }
        /// <summary>
        /// Exprime une quantité (par exemple un nombre d’articles)
        /// Optionnelle
        /// Nombre entier
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=105"/>
        public int Quantity { get; set; }
        /// <summary>
        /// Identifiant que le commerçant donne à un article.
        /// Obligatoire si applicable
        /// Chaîne
        /// Jusqu’à 255 caractères
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=105"/>
        public string ProductSKU { get; set; }
        /// <summary>
        /// Indicateur du niveau de risque lié à un produit.
        /// Optionnelle
        /// Chaîne
        /// Valeurs possibles :
        /// « low » : faible risque
        /// « normal » : risque moyen
        /// « high » : risque élevé
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=105"/>
        public string ProductRisk { get; set; }
    }
}