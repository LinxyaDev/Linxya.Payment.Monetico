using System.Runtime.Serialization;

namespace Linxya.Payment.Monetico.Enums
{
    /// <summary>
    /// Indique le souhait du commerçant concernant la cinématique de l’authentification 3DSecure 2.X.
    /// Il s’agit uniquement d’un souhait et ce dernier peut ne pas être approuvé par les banques émettrices.
    /// </summary>
    /// <remarks>
    /// Please refer to 3DSecure V2 protocol for more details about these values.
    /// </remarks>
    /// <see href="https://www.monetico-paiement.fr/fr/info/documentations/Monetico_Paiement_documentation_technique_v2.0.pdf#page=110"/>
    public enum AuthThreeDSecurePreference
    {
        /// <summary>
        /// Pas de préférence (choix par défaut)
        /// </summary>
        [EnumMember(Value = "no_preference")]
        NoPreference = 0,
        /// <summary>
        /// Challenge souhaité
        /// </summary>
        [EnumMember(Value = "challenge_preferred")]
        ChallengePreferred,
        /// <summary>
        /// Challenge requis
        /// </summary>
        [EnumMember(Value = "challenge_mandated")]
        ChallengeMandated,
        /// <summary>
        /// Pas de challenge demandé
        /// </summary>
        [EnumMember(Value = "no_challenge_requested")]
        NoChallengeRequested,
        /// <summary>
        /// Pas de challenge demandé -> l’authentification forte du client a déjà été réalisée par le commerçant.
        /// </summary>
        [EnumMember(Value = "no_challenge_requested_strong_authentication")]
        NoChallengeRequestedBecauseStrongAuthenticationHasBeenPerformed,
        /// <summary>
        /// Pas de challenge demandé –> demande d’exemption car le commerçant est un bénéficiaire de confiance du client.
        /// </summary>
        [EnumMember(Value = "no_challenge_requested_trusted_third_party")]
        NoChallengeRequestedBecauseMerchantIsATrustedThirdParty,
        /// <summary>
        /// Pas de challenge demandé –> demande d’exemption pour un autre motif que cité précédemment(par exemple : petit montant)
        /// </summary>
        [EnumMember(Value = "no_challenge_requested_risk_analysis")]
        NoChallengeRequestedBecauseRiskAnalysisHasBeenCarriedOut,
    }
}
