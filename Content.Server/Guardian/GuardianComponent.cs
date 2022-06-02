using Content.Shared.Actions;
using Content.Shared.Actions.ActionTypes;
using Robust.Shared.Utility;

namespace Content.Server.Guardian
{
    /// <summary>
    /// Given to guardians to monitor their link with the host
    /// </summary>
    [RegisterComponent]
    public sealed class GuardianComponent : Component
    {
        /// <summary>
        /// The guardian host entity
        /// </summary>
        public EntityUid Host;

        /// <summary>
        /// Percentage of damage reflected from the guardian to the host
        /// </summary>
        [ViewVariables]
        [DataField("damageShare")]
        public float DamageShare { get; set; } = 0.85f;

        /// <summary>
        /// Maximum distance the guardian can travel before it's forced to recall, use YAML to set
        /// </summary>
        [ViewVariables]
        [DataField("distanceAllowed")]
        public float DistanceAllowed { get; set; } = 5f;

        [DataField("action")]
        public InstantAction Action = new()
        {
            Name = "action-name-guardian-lovetap",
            Description = "action-description-guardian-lovetap",
            Icon = new SpriteSpecifier.Texture(new ResourcePath("Interface/Actions/lovetap.png")),
            UseDelay = TimeSpan.FromSeconds(120), // can only be used once anyways.
            CheckCanInteract = false, // allow use while stunned, etc. Gets removed anyways.
            Event = new GuardianLovetapActionEvent()
        };

        /// <summary>
        /// If the guardian is currently manifested
        /// </summary>
        public bool GuardianLoose = false;

        public sealed class GuardianLovetapActionEvent : InstantActionEvent { };

    }
}
