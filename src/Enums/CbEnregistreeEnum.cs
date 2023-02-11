using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Booléen indiquant si la carte a été enregistrée sous un aliascb donné.
    /// </summary>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
    public enum CbEnregistreeEnum
    {
        /// <summary>
        /// Tous les autres cas
        /// </summary>
        Autre = 0,
        /// <summary>
        /// Le client a saisi une carte de paiement et elle a été enregistrée sous l’aliascb envoyé
        /// </summary>
        CbEnregistree = 1,
    }
}
