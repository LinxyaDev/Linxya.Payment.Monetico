using Linxya.Payment.Monetico.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Linxya.Payment.Monetico.Models.Response
{
    /// <summary>
    /// Modèle pour la réponse venant de Monético
    /// </summary>
    public class MoneticoResponse
    {
        /// <summary>
        /// Toutes les données, venant soit des "form" (si "post"), soit des "query" (si "get")
        /// </summary>
        [BindNever]
        public IDictionary<string, string>? AllData { get; set; }
        /// <summary>
        /// Le résultat du paiement
        /// Chaîne
        /// Valeurs possibles :
        ///  payetest : paiement accepté (en « sandbox » uniquement)
        ///  paiement : paiement accepté(en Production uniquement)
        ///  annulation : paiement refusé
        /// En paiement fractionné, pour les mises en recouvrement automatique des échéances de rang > 1 :
        ///  paiement_pf[N] : paiement accepté de l’échéance N (N entre 2 et 4)
        ///  Annulation_pf[N] : paiement refusé définitivement de l’échéance N (N entre 2 et 4)
        /// </summary>
        /// <remarks>
        /// En cas de paiement refusé, une autorisation ultérieure pourra encore être délivrée pour la même référence.
        /// Le code « payetest » n’est envoyé que pour des paiements effectués dans l’environnement « sandbox ».
        /// Si ce code est présent lors d’un paiement en production, il s’agit d’une anomalie.
        /// </remarks>
        /// <example>
        /// paiement
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=25"/>
        [ModelBinder(Name = "code-retour")]
        public CodeRetourEnum? CodeRetour { get; set; }
        /// <summary>
        /// Sceau issu de la certification de données envoyées au système de paiement.
        /// 40 caractères hexadécimaux
        /// [A-F]{40}
        /// </summary>
        /// <example>
        /// f97861e0f3e296b7eece2cfd86dc46c43ac88049
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=25"/>
        [ModelBinder(Name = "MAC")]
        public string? Mac { get; set; }
        /// <summary>
        /// Numéro de votre TPE virtuel
        /// 7 caractères alphanumériques
        /// [A-Za-z0-9]{7}
        /// </summary>
        /// <example>
        /// 1234567
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=25"/>
        [ModelBinder(Name = "TPE")]
        public string? Tpe { get; set; }
        private string? _montantString;
        /// <summary>
        /// Montant TTC de la commande
        /// Un nombre entier
        /// Un point décimal(optionnel)
        /// Un nombre entier de 2 chiffres(optionnel)
        /// Une devise sur 3 caractères alphabétiques ISO4217(EUR, USD, etc.)
        /// [0-9]+(\.[0-9]{1,2})?[A-Z]{3}
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas des modes de paiement HORS préautorisation
        /// </remarks>
        /// <example>
        /// 95.25EUR
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26"/>
        [ModelBinder(Name = "montant")]
        public string? MontantString
        {
            get => _montantString;
            set
            {
                _montantString = value;
                (Montant, MontantCurrency) = SplitMontant(value);
            }
        }
        /// <summary>
        /// Montant TTC de la commande
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas des modes de paiement HORS préautorisation
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26"/>
        [BindNever]
        public decimal? Montant { get; private set; }
        /// <summary>
        /// Devise du montant TTC de la commande
        /// </summary>
        [BindNever]
        public string? MontantCurrency { get; private set; }
        private string? _montantEstimeString;
        /// <summary>
        /// Montant TTC estimé de la commande
        /// Un nombre entier
        /// Un point décimal(optionnel)
        /// Un nombre entier de 2 chiffres(optionnel)
        /// Une devise sur 3 caractères alphabétiques ISO4217(EUR, USD, etc.)
        /// [0-9]+(\.[0-9]{1,2})?[A-Z]{3}
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas du mode de paiement préautorisation
        /// </remarks>
        /// <example>
        /// 95.25EUR
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26"/>
        [ModelBinder(Name = "montantestime")]
        public string? MontantEstimeString
        {
            get => _montantEstimeString;
            set
            {
                _montantEstimeString = value;
                (MontantEstime, MontantEstimeCurrency) = SplitMontant(value);
            }
        }
        /// <summary>
        /// Montant TTC estimé de la commande
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas du mode de paiement préautorisation
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26"/>
        [BindNever]
        public decimal? MontantEstime { get; private set; }
        /// <summary>
        /// Devise du montant TTC estimé de la commande
        /// </summary>
        [BindNever]
        public string? MontantEstimeCurrency { get; private set; }
        /// <summary>
        /// Référence unique de la commande.
        /// 50 caractères alphanumériques maximum
        /// </summary>
        /// <example>
        /// REF7896543
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26"/>
        [ModelBinder(Name = "reference")]
        public string? Reference { get; set; }
        /// <summary>
        /// Zone de texte libre fournie lors de la phase « Aller »
        /// 3200 caractères maximum
        /// </summary>
        /// <example>
        /// Livraison relais colis rue des tourterelles
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26"/>
        [ModelBinder(Name = "texte-libre")]
        public string? TexteLibre { get; set; }
        private string? _dateString;
        /// <summary>
        /// Date de la demande d’autorisation de la commande
        /// JJ/MM/AAAA_a_HH:MM:SS
        /// </summary>
        /// <example>
        /// 24/05/2019_a_10:00:25
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26/>
        [ModelBinder(Name = "date")]
        public string? DateString
        {
            get => _dateString;
            set
            {
                _dateString = value;
                Date = ConvertDate(value);
            }
        }

        /// <summary>
        /// Date de la demande d’autorisation de la commande
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=26/>
        [BindNever]
        public DateTime? Date { get; private set; }
        private string? _cvxString;
        /// <summary>
        /// Indique si le cryptogramme visuel a été saisi lors de la transaction.
        /// oui: si le cryptogramme visuel a été saisi
        /// non: sinon
        /// </summary>
        /// <example>
        /// oui
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        [ModelBinder(Name = "cvx")]
        public string? CvxString
        {
            get => _cvxString;
            set
            {
                _cvxString = value;
                if (string.Compare(value, "oui") == 0)
                {
                    Cvx = true;
                }
                else if (string.Compare(value, "non") == 0)
                {
                    Cvx = true;
                }
                else
                {
                    Cvx = null;
                }
            }
        }
        /// <summary>
        /// Indique si le cryptogramme visuel a été saisi lors de la transaction.
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        [BindNever]
        public bool? Cvx { get; private set; }
        /// <summary>
        /// Date de validité de la carte de paiement utilisée pour effectuer le paiement
        /// MMAA
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <example>
        /// 1019
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        [ModelBinder(Name = "vld")]
        public string? Vld { get; set; }
        /// <summary>
        /// Code réseau de la carte sur 2 positions alphabétiques parmi les valeurs possibles :
        ///  AM American Express
        ///  CB GIE CB
        ///  MC Mastercard
        ///  VI Visa
        ///  na Non disponible
        /// </summary>
        /// <remarks>
        /// La valeur « na » est systématiquement retournée dans l’environnement de test
        /// </remarks>
        /// <example>
        /// VI
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        [ModelBinder(Name = "brand")]
        public BrandEnum? Brand { get; set; }
        /// <summary>
        /// Numéro d’autorisation tel que fourni par la banque émettrice.
        /// Chaîne
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas où l’autorisation a été accordée
        /// </remarks>
        /// <example>
        /// 000002
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        [ModelBinder(Name = "numauto")]
        public string? NumAuto { get; set; }
        private string? _authentificationString;
        /// <summary>
        /// Informations liées à l’authentification du client notamment pour 3DSecure.
        /// Document JSON/UTF-8 encodé en base 64.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        /// <seealso href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
        [ModelBinder(Name = "authentification")]
        public string? AuthentificationString
        {
            get => _authentificationString;
            set
            {
                _authentificationString = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        Authentification = JsonConvert.DeserializeObject<MoneticoAuthenticationResponse>(
                            Encoding.UTF8.GetString(
                                Convert.FromBase64String(value)
                                ),
                            // Without this custom JsonSerializerSettings -> one error stop the conversion
                            // With this custom JsonSerializerSettings -> error on an item conversion -> null for this element
                            new JsonSerializerSettings()
                            {
                                Error = (se, ev) => ev.ErrorContext.Handled = true
                            }
                        );
                    }
                    catch (Exception)
                    {
                        Authentification = null;
                    }
                }
            }
        }
        /// <summary>
        /// Informations liées à l’authentification du client notamment pour 3DSecure.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=27"/>
        /// <seealso href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=108"/>
        [BindNever]
        public MoneticoAuthenticationResponse? Authentification { get; private set; }

        /// <summary>
        /// Précise le type de carte utilisée pour réaliser la transaction.
        /// Valeurs possibles :
        ///  credit : carte de crédit ou à débit différé
        ///  debit : carte de débit
        ///  prepaye : carte prépayée
        ///  inconnu : impossible de déterminer le type de carte
        /// </summary>
        /// <example>
        /// credit
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
        [ModelBinder(Name = "usage")]
        public UsageEnum? Usage { get; set; }
        /// <summary>
        /// Précise le type de compte associé à la carte de paiement.
        /// Valeurs possibles :
        ///  particulier : compte d’un particulier
        ///  commercial : compte d’un professionnel
        ///  inconnu : impossible de déterminer le type de compte
        /// </summary>
        /// <example>
        /// particulier
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
        [ModelBinder(Name = "typecompte")]
        public TypeCompteEnum? TypeCompte { get; set; }
        private string? _ecardString;
        /// <summary>
        /// Explicite si la carte utilisée pour le paiement est virtuelle ou non.
        /// Valeurs possibles :
        ///  oui
        ///  non
        /// </summary>
        /// <example>
        /// oui
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
        [ModelBinder(Name = "ecard")]
        public string? EcardString
        {
            get => _ecardString;
            set
            {
                _ecardString = value;
                if (string.Compare(value, "oui") == 0)
                {
                    Ecard = true;
                }
                else if (string.Compare(value, "non") == 0)
                {
                    Ecard = true;
                }
                else
                {
                    Ecard = null;
                }
            }
        }
        /// <summary>
        /// Explicite si la carte utilisée pour le paiement est virtuelle ou non.
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
        [BindNever]
        public bool? Ecard { get; private set; }

        /// <summary>
        /// Motif du refus de la demande de paiement.
        /// Valeurs possibles :
        ///  Appel Phonie : la banque du client demande des informations complémentaires
        ///  Refus : la banque du commerçant ou du client refuse d’accorder l’autorisation
        ///  Interdit : la banque du commerçant ou du client refuse d’accorder l’autorisation
        ///  filtrage : la demande de paiement a été bloquée par le paramétrage de filtrage que le commerçant a mis en place dans son Module Prévention Fraude
        ///  scoring : la demande de paiement a été bloquée par le paramétrage de scoring que le commerçant a mis en place dans son Module Prévention Fraude
        ///  3DSecure : si le refus est lié à une authentification 3DSecure négative reçue de la banque du porteur
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas où la demande de paiement a été refusée
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
        [ModelBinder(Name = "motifrefus")]
        public MotifRefusEnum? MotifRefus { get; set; }
        /// <summary>
        /// Motif du refus détaillé de la demande d’autorisation.
        /// Valeurs possibles :
        ///  Refus banque : la banque du client ou du commerçant refuse d’accorder l’autorisation
        ///  Refus emetteur : la banque du client refuse d’accorder l’autorisation
        ///  Refus critique : la banque du client refuse d’accorder l’autorisation. Contrairement au « Refus banque » et au « Refus emetteur » ce refus est définitif.
        ///  Refus repli VADS : la banque du client refuse d’accorder l’autorisation et requiert une authentification du client.
        ///  Refus temporaire : la demande d’autorisation a été refusée mais pourrait être retentée.
        ///  Refus technique : la demande d’autorisation a été refusée en raison d’un problème technique.
        ///  Refus autres : autre motifs de refus.
        ///  Refus test : simulation d’un test de refus d’autorisation en environnement de validation.
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas où la demande d’autorisation a été refusée
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=28"/>
        [ModelBinder(Name = "motifrefusautorisation")]
        public string? MotifRefusAutorisation { get; set; }
        /// <summary>
        /// Code pays de la banque émettrice de la carte de paiement
        /// Norme ISO 3166-1
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription du module prévention fraude
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=29"/>
        [ModelBinder(Name = "originecb")]

        public string? OrigineCb { get; set; }
        /// <summary>
        /// Code BIN de la banque du porteur de la carte de paiement.
        /// Le format dépend de la longueur du numéro de carte :
        /// - 8 chiffres pour les numéros de cartes ayant une longueur de 16 chiffres ou plus
        /// - 6 chiffres suivis de 2 caractères ‘X’ pour les numéros de carte ayant une longueur de moins de 16 chiffres
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription du module prévention fraude
        /// </remarks>
        /// <example>
        /// 12345678
        /// 123456XX
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=29"/>
        [ModelBinder(Name = "bincb")]
        public string? BinCb { get; set; }
        /// <summary>
        /// Hachage irréversible (HMAC-SHA1) du numéro de la carte de paiement utilisée
        /// pour effectuer le paiement(identifiant de manière unique une carte de paiement pour un commerçant donné)
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription du module prévention fraude
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=29"/>
        [ModelBinder(Name = "hpancb")]
        public string? HpanCb { get; set; }
        /// <summary>
        /// Adresse IP du client ayant fait la transaction
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription du module prévention fraude
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=29"/>
        [ModelBinder(Name = "ipclient")]
        public string? IpClient { get; set; }
        /// <summary>
        /// Code pays de l’origine de la transaction.
        /// Norme ISO 3166-1
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription du module prévention fraude
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=29"/>
        [ModelBinder(Name = "originetr")]
        public string? OrigineTr { get; set; }
        private string? _montantEchString;
        /// <summary>
        /// Montant de l’échéance en cours
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas du paiement fractionné
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
        [ModelBinder(Name = "montantech")]
        public string? MontantEchString
        {
            get => _montantEchString;
            set
            {
                _montantEchString = value;
                (MontantEch, MontantEchCurrency) = SplitMontant(value);
            }
        }

        /// <summary>
        /// Montant de l’échéance en cours
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas du paiement fractionné
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
        [BindNever]
        public decimal? MontantEch { get; private set; }
        /// <summary>
        /// Devise du montant de l’échéance en cours
        /// </summary>
        [BindNever]
        public string? MontantEchCurrency { get; private set; }
        /// <summary>
        /// Numéro de dossier pour les TPE en pré autorisation.
        /// 12 caractères alphanumériques maximum
        /// </summary>
        /// <example>
        /// 20150901PRE1
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
        [ModelBinder(Name = "numero_dossier")]
        public string? NumeroDossier { get; set; }
        /// <summary>
        /// Type de facture à générer pour les TPE en pré autorisation.
        /// Valeurs possibles :
        ///  preauto
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un TPE en pré autorisation
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
        [ModelBinder(Name = "typefacture")]
        public TypeFactureEnum? TypeFacture { get; set; }
        private string? _filtrageCauseString { get; set; }
        /// <summary>
        /// Numéros des types de filtres bloquant le paiement (cf. tableau « Retours Module Prévention Fraude – détails »).
        /// Valeurs possibles :
        ///  1 : Adresse IP
        ///  2 : Numéro de carte
        ///  3 : BIN de carte
        ///  4 : Pays de la carte
        ///  5 : Pays de l’IP
        ///  6 : Cohérence pays de la carte / pays de l’IP
        ///  7 : Email jetable
        ///  8 : Limitation en montant pour une CB sur une période donnée
        ///  9 : Limitation en nombre de transactions pour une CB sur une période donnée
        ///  11 : Limitation en nombre de transactions par alias sur une période donnée
        ///  12 : Limitation en montant par alias sur une période donnée
        ///  13 : Limitation en montant par IP sur une période donnée
        ///  14 : Limitation en nombre de transactions par IP sur une période donnée
        ///  15 : Testeurs de cartes
        ///  16 : Limitation en nombre d’alias par CB
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un filtrage du paiement ou si le mode information est activé.
        /// Si plusieurs filtres bloquent le paiement, ceux-ci sont séparés par des tirets.Les causes et les valeurs correspondantes étant dans le même ordre.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
        /// <seealso href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
        [ModelBinder(Name = "filtragecause")]
        public string? FiltrageCauseString
        {
            get => _filtrageCauseString;
            set
            {
                _filtrageCauseString = value;
                try
                {
                    FiltrageCause = value?.Split("-", StringSplitOptions.RemoveEmptyEntries).Select(str => (FiltrageCauseEnum)int.Parse(str)).ToArray();
                }
                catch (Exception)
                {
                    FiltrageCause = null;
                }
            }
        }
        /// <summary>
        /// Numéros des types de filtres bloquant le paiement (cf. tableau « Retours Module Prévention Fraude – détails »).
        /// Valeurs possibles :
        ///  1 : Adresse IP
        ///  2 : Numéro de carte
        ///  3 : BIN de carte
        ///  4 : Pays de la carte
        ///  5 : Pays de l’IP
        ///  6 : Cohérence pays de la carte / pays de l’IP
        ///  7 : Email jetable
        ///  8 : Limitation en montant pour une CB sur une période donnée
        ///  9 : Limitation en nombre de transactions pour une CB sur une période donnée
        ///  11 : Limitation en nombre de transactions par alias sur une période donnée
        ///  12 : Limitation en montant par alias sur une période donnée
        ///  13 : Limitation en montant par IP sur une période donnée
        ///  14 : Limitation en nombre de transactions par IP sur une période donnée
        ///  15 : Testeurs de cartes
        ///  16 : Limitation en nombre d’alias par CB
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un filtrage du paiement ou si le mode information est activé.
        /// Si plusieurs filtres bloquent le paiement, ceux-ci sont séparés par des tirets.Les causes et les valeurs correspondantes étant dans le même ordre.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=30"/>
        /// <seealso href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
        [BindNever]
        public FiltrageCauseEnum[]? FiltrageCause { get; private set; }
        private string? _filtrageValeurString;
        /// <summary>
        /// Données ayant engendré le blocage
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un filtrage du paiement ou si le mode information est activé.
        /// Si plusieurs filtres bloquent le paiement, ceux-ci sont séparés par des tirets.Les causes et les valeurs correspondantes étant dans le même ordre.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [ModelBinder(Name = "filtragevaleur")]
        public string? FiltrageValeurString
        {
            get => _filtrageValeurString;
            set
            {
                _filtrageValeurString = value;
                try
                {
                    FiltrageValeur = value?.Split("-", StringSplitOptions.RemoveEmptyEntries);
                }
                catch (Exception)
                {
                    FiltrageValeur = null;
                }
            }
        }
        /// <summary>
        /// Données ayant engendré le blocage
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un filtrage du paiement ou si le mode information est activé.
        /// Si plusieurs filtres bloquent le paiement, ceux-ci sont séparés par des tirets.Les causes et les valeurs correspondantes étant dans le même ordre.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [BindNever]
        public string[]? FiltrageValeur { get; private set; }
        private string? _filtrageEtatString;
        /// <summary>
        /// Indique, s’il est présent uniquement, que le filtrage est en mode « information ».
        /// Valeurs possibles :
        ///  information : Mode information du filtrage
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un filtrage du paiement ou si le mode information est activé.
        /// Si plusieurs filtres bloquent le paiement, ceux-ci sont séparés par des tirets.Les causes et les valeurs correspondantes étant dans le même ordre.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [ModelBinder(Name = "filtrage_etat")]
        public string? FiltrageEtatString
        {
            get => _filtrageEtatString;
            set
            {
                _filtrageEtatString = value;
                try
                {
                    FiltrageEtat = value?.Split("-", StringSplitOptions.RemoveEmptyEntries).Select(str => JsonConvert.DeserializeObject<FiltrageEtatEnum>($"\"{str}\"")).ToArray();
                }
                catch (Exception)
                {
                    FiltrageEtat = null;
                }
            }
        }
        /// <summary>
        /// Indique, s’il est présent uniquement, que le filtrage est en mode « information ».
        /// Valeurs possibles :
        ///  information : Mode information du filtrage
        /// </summary>
        /// <remarks>
        /// Uniquement dans le cas d’un filtrage du paiement ou si le mode information est activé.
        /// Si plusieurs filtres bloquent le paiement, ceux-ci sont séparés par des tirets.Les causes et les valeurs correspondantes étant dans le même ordre.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [BindNever]
        public FiltrageEtatEnum[]? FiltrageEtat { get; private set; }
        private CbEnregistreeEnum? _cbEnregistreeEnum;
        /// <summary>
        /// Booléen indiquant si la carte a été enregistrée sous un aliascb donné.
        /// Valeurs posibles :
        ///  1 : Le client a saisi une carte de paiement et elle a été enregistrée sous l’aliascb envoyé
        ///  0 : Tous les autres cas
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription de l’option paiement express
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [ModelBinder(Name = "cbenregistree")]
        public CbEnregistreeEnum? CbEnregistreeEnum
        {
            get => _cbEnregistreeEnum;
            set
            {
                _cbEnregistreeEnum = value;
                if (_cbEnregistreeEnum.HasValue)
                {
                    CbEnregistree = _cbEnregistreeEnum.Value != Enums.CbEnregistreeEnum.Autre;
                }
                else
                {
                    CbEnregistree = null;
                }
            }
        }
        /// <summary>
        /// Booléen indiquant si la carte a été enregistrée sous un aliascb donné.
        /// </summary>
        /// <remarks>
        /// Uniquement en cas de souscription de l’option paiement express
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [BindNever]
        public bool? CbEnregistree { get; private set; }
        /// <summary>
        /// Le numéro de carte tronqué en conformité avec PCI DSS.
        /// Le format dépend de la longueur du numéro de carte :
        /// - 8 premiers et 2 derniers chiffres de la carte de paiement du client, séparés par des étoiles pour les numéros de carte ayant une longueur de 16 chiffres ou plus
        /// - 6 premiers chiffres, 6 étoiles, le reste des chiffres de la carte de paiement du client pour les numéros de carte ayant une longueur de moins de 16 chiffres
        /// </summary>
        /// <remarks>
        /// Présent systématiquement pour les paiements par carte.
        /// Absent pour les paiements sans saisie de carte sur la page Monetico Paiement (Paypal...)
        /// </remarks>
        /// <example>
        /// 12345678******12
        /// 123456******123
        /// </example>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [ModelBinder(Name = "cbmasquee")]
        public string? CbMasquee { get; set; }
        /// <summary>
        /// Moyen de paiement utilisé.
        /// Valeurs possibles :
        ///  CB
        ///  paypal
        ///  1euro
        ///  3xcb
        ///  4xcb
        ///  lyfpay
        ///  sofort
        ///  giropay
        /// </summary>
        /// <remarks>
        /// Dans le cas d’un paiement l’aide du wallet Paylib, la valeur sera CB et la paramètre « wallet » indiquera le nom du wallet
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=31"/>
        [ModelBinder(Name = "modepaiement")]
        public PaymentProtocolEnum? ModePaiement { get; set; }
        /// <summary>
        /// Nom du wallet utilisé pour le paiement uniquement dans le cas Paylib.
        /// Valeurs possibles :
        ///  paylib
        /// </summary>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
        [ModelBinder(Name = "wallet")]
        public WalletEnum? Wallet { get; set; }
        /// <summary>
        /// Indique le statut de débrayage de l’authentification du porteur.
        /// Valeurs possibles :
        ///  0 : débrayage non demandé
        ///  1 : débrayage accordé
        ///  -1 : débrayage non accordé en raison du type de carte de paiement
        ///  -2 : débrayage non accordé en raison des options du paiement
        /// </summary>
        /// <remarks>
        /// Uniquement si les options de débrayage par montant ou formulaires sont activées.
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
        [ModelBinder(Name = "statutdebrayageauthentification")]
        public StatutDebrayageAuthentificationEnum? StatutDebrayageAuthentification { get; set; }
        /// <summary>
        /// Nom qui a été assigné à la carte de paiement et qui sera visible par exemple lors de la consultation du wallet par le client.
        /// [0-9A-Za-z_,\.\- ]{1,20}
        /// </summary>
        /// <remarks>
        /// Uniquement si un nom a été associé à la carte lors de son enregistrement
        /// </remarks>
        /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=32"/>
        [ModelBinder(Name = "nomcartesequestree")]
        public string? NomCarteSequestree { get; set; }

        /// <summary>
        /// Transform string montant in decimal + currency
        /// </summary>
        /// <param name="montantString">montant source string</param>
        /// <returns>Decimal/currency tuple</returns>
        protected (decimal? montant, string? currency) SplitMontant(string? montantString)
        {
            (decimal? montant, string? currency) result = (null, null);
            try
            {
                result.montant = decimal.Parse(montantString.Substring(0, montantString.Length - 3), CultureInfo.InvariantCulture);
                result.currency = montantString.Substring(montantString.Length - 3, 3);
            }
            catch (Exception) { }
            if (result.montant == null || result.currency == null)
            {
                result.montant = null;
                result.currency = null;
            }
            return result;
        }
        /// <summary>
        /// Convert date from the correct format
        /// JJ/MM/AAAA_a_HH:MM:SS
        /// or:
        /// JJ/MM/AAAA:HH:MM:SS
        /// </summary>
        /// <param name="dateString">date in string format</param>
        /// <returns>date in DateTime? format</returns>
        private DateTime? ConvertDate(string? dateString)
        {
            DateTime? result = null;
            try
            {
                result = DateTime.ParseExact(dateString.Replace("_a_", ":"),
                     new string[] { "dd/MM/yyyy:HH:mm:ss" },
                     CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            }
            catch (Exception) { }
            return result;
        }

    }
}
