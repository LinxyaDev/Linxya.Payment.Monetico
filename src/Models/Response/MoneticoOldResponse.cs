using Newtonsoft.Json;

namespace Linxya.Payment.Monetico.Models.Response
{
    /// <summary>
    /// Pour un ancien appel à l’interface « Retour ».
    /// </summary>
    /// <remarks>
    /// Cette section ne s’adresse qu’aux commerçants effectuant la transition depuis l’ancien calcul
    /// de sceau MAC vers le nouveau et devant gérer des appels à l’interface retour pour des
    /// commandes créées avant celle-ci.Elle doit être ignorée dans tous les autres cas.Elle décrit
    /// les champs retournés et le calcul du sceau les validant, dans le cas d’une version 3.0.
    /// </remarks>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=84"/>
    public class MoneticoOldResponse
    {
        /// <summary>
        /// Toutes les données, venant soit des "form" (si "post"), soit des "query" (si "get")
        /// </summary>
        [JsonIgnore]
        public IDictionary<string, string> AllData { get; set; }
        [JsonProperty("MAC")]
        public string Mac { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("TPE")]
        public string Tpe { get; set; }
        [JsonProperty("montant")]
        public string Montant { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("texte-libre")]
        public string TexteLibre { get; set; }
        [JsonProperty("code-retour")]
        public string CodeRetour { get; set; }
        [JsonProperty("cvx")]
        public string Cvx { get; set; }
        [JsonProperty("vld")]
        public string Vld { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("status3ds")]
        public string Status3ds { get; set; }
        [JsonProperty("numauto")]
        public string NumAuto { get; set; }
        [JsonProperty("motifrefus")]
        public string MotifRefus { get; set; }
        [JsonProperty("originecb")]
        public string OrigineCb { get; set; }
        [JsonProperty("bincb")]
        public string BinCb { get; set; }
        [JsonProperty("hpancb")]
        public string HpanCb { get; set; }
        [JsonProperty("ipclient")]
        public string IpClient { get; set; }
        [JsonProperty("originetr")]
        public string OrigineTr { get; set; }
        [JsonProperty("veres")]
        public string VeRes { get; set; }
        [JsonProperty("pares")]
        public string PaRes { get; set; }
        [JsonProperty("montantech")]
        public string MontantEch { get; set; }
        [JsonProperty("filtragecause")]
        public string FiltrageCause { get; set; }
        [JsonProperty("filtragevaleur")]
        public string FiltrageValeur { get; set; }
        [JsonProperty("filtrage_etat")]
        public string FiltrageEtat { get; set; }
        [JsonProperty("cbenregistree")]
        public string CbEnregistree { get; set; }
        [JsonProperty("cbmasquee")]
        public string CbMasquee { get; set; }
        [JsonProperty("modepaiement")]
        public string ModePaiement { get; set; }
        [JsonProperty("nomcartesequestree")]
        public string NomCarteSequestree { get; set; }
    }
}
