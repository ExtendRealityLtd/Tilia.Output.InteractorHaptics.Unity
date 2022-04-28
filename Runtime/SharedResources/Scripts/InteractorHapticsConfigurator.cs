namespace Tilia.Output.InteractorHaptics
{
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Haptics;
    using Zinnia.Rule;

    /// <summary>
    /// Sets up the Interactor Haptics Prefab based on the provided user settings.
    /// </summary>
    public class InteractorHapticsConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractorHapticsFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractorHapticsFacade Facade
        {
            get
            {
                return facade;
            }
            protected set
            {
                facade = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked RulesMatcher.")]
        [SerializeField]
        [Restricted]
        private RulesMatcher matcher;
        /// <summary>
        /// The linked <see cref="RulesMatcher"/>.
        /// </summary>
        public RulesMatcher Matcher
        {
            get
            {
                return matcher;
            }
            protected set
            {
                matcher = value;
            }
        }
        [Tooltip("The linked ListContainsRule for the left controller.")]
        [SerializeField]
        [Restricted]
        private ListContainsRule leftControllerRule;
        /// <summary>
        /// The linked <see cref="ListContainsRule"/> for the left controller.
        /// </summary>
        public ListContainsRule LeftControllerRule
        {
            get
            {
                return leftControllerRule;
            }
            protected set
            {
                leftControllerRule = value;
            }
        }
        [Tooltip("The linked ListContainsRule for the right controller.")]
        [SerializeField]
        [Restricted]
        private ListContainsRule rightControllerRule;
        /// <summary>
        /// The linked <see cref="ListContainsRule"/> for the right controller.
        /// </summary>
        public ListContainsRule RightControllerRule
        {
            get
            {
                return rightControllerRule;
            }
            protected set
            {
                rightControllerRule = value;
            }
        }
        [Tooltip("The GameObject containing the default haptic processing logic.")]
        [SerializeField]
        [Restricted]
        private GameObject defaultHapticProcessors;
        /// <summary>
        /// The <see cref="GameObject"/> containing the default haptic processing logic.
        /// </summary>
        public GameObject DefaultHapticProcessors
        {
            get
            {
                return defaultHapticProcessors;
            }
            protected set
            {
                defaultHapticProcessors = value;
            }
        }
        [Tooltip("The GameObject containing the profile haptic processing logic.")]
        [SerializeField]
        [Restricted]
        private GameObject profileHapticProcessors;
        /// <summary>
        /// The <see cref="GameObject"/> containing the profile haptic processing logic.
        /// </summary>
        public GameObject ProfileHapticProcessors
        {
            get
            {
                return profileHapticProcessors;
            }
            protected set
            {
                profileHapticProcessors = value;
            }
        }
        [Tooltip("The GameObject containing the logic for canceling existing haptic processes.")]
        [SerializeField]
        [Restricted]
        private GameObject cancelHapticProcessors;
        /// <summary>
        /// The <see cref="GameObject"/> containing the logic for canceling existing haptic processes.
        /// </summary>
        public GameObject CancelHapticProcessors
        {
            get
            {
                return cancelHapticProcessors;
            }
            protected set
            {
                cancelHapticProcessors = value;
            }
        }
        #endregion

        /// <summary>
        /// Processes the default haptics on the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to process.</param>
        public virtual void ProcessDefaultHapticsOnMatch(GameObject interactor)
        {
            ProfileHapticProcessors.SetActive(false);
            CancelHapticProcessors.SetActive(false);
            DefaultHapticProcessors.SetActive(true);
            Matcher.Match(interactor);
        }

        /// <summary>
        /// Processes the haptics profile on the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to process.</param>
        public virtual void ProcessProfileHapticsOnMatch(GameObject interactor)
        {
            DefaultHapticProcessors.SetActive(false);
            CancelHapticProcessors.SetActive(false);
            ProfileHapticProcessors.SetActive(true);
            Matcher.Match(interactor);
        }

        /// <summary>
        /// Cancels the haptic processes running on the given Interactor
        /// </summary>
        /// <param name="interactor">The Interactor to cancel on.</param>
        public virtual void ProcessCancelHapticsOnMatch(GameObject interactor)
        {
            DefaultHapticProcessors.SetActive(false);
            ProfileHapticProcessors.SetActive(false);
            CancelHapticProcessors.SetActive(true);
            Matcher.Match(interactor);
        }

        /// <summary>
        /// Cancels the haptics on the left controller.
        /// </summary>
        public virtual void CancelHapticsOnLeftController()
        {
            Facade.TrackedAlias.CancelAllHapticsOnLeftController();
        }

        /// <summary>
        /// Cancels the haptics on the right controller.
        /// </summary>
        public virtual void CancelHapticsOnRightController()
        {
            Facade.TrackedAlias.CancelAllHapticsOnRightController();
        }

        /// <summary>
        /// Begins processing the default haptics associated with the left controller.
        /// </summary>
        public virtual void BeginDefaultHapticsOnLeftController()
        {
            CancelHapticsOnLeftController();
            HapticProcess process = Facade.TrackedAlias.ActiveLeftHapticProcess;
            float? cachedIntensity = UpdateIntensity(process);

            Facade.TrackedAlias.BeginHapticProcessOnLeftController();
            ResetIntensity(process, cachedIntensity);
        }

        /// <summary>
        /// Begins processing the default haptics associated with the right controller.
        /// </summary>
        public virtual void BeginDefaultHapticsOnRightController()
        {
            CancelHapticsOnRightController();
            HapticProcess process = Facade.TrackedAlias.ActiveRightHapticProcess;
            float? cachedIntensity = UpdateIntensity(process);

            Facade.TrackedAlias.BeginHapticProcessOnRightController();
            ResetIntensity(process, cachedIntensity);
        }

        /// <summary>
        /// Begins processing the set profile haptics associated with the left controller.
        /// </summary>
        public virtual void BeginProfileHapticsOnLeftController()
        {
            CancelHapticsOnLeftController();
            Facade.TrackedAlias.BeginHapticProcessOnLeftController(Facade.Profile);
        }

        /// <summary>
        /// Begins processing the set profile haptics associated with the right controller.
        /// </summary>
        public virtual void BeginProfileHapticsOnRightController()
        {
            CancelHapticsOnRightController();
            Facade.TrackedAlias.BeginHapticProcessOnRightController(Facade.Profile);
        }

        /// <summary>
        /// Configures the rules for the left controller matching rule.
        /// </summary>
        public virtual void ConfigureLeftControllerRules()
        {
            ConfigureControllerRules(Facade.LeftInteractor, LeftControllerRule);
        }

        /// <summary>
        /// Configures the rules for the right controller matching rule.
        /// </summary>
        public virtual void ConfigureRightControllerRules()
        {
            ConfigureControllerRules(Facade.RightInteractor, RightControllerRule);
        }

        protected virtual void OnEnable()
        {
            ConfigureLeftControllerRules();
            ConfigureRightControllerRules();
        }

        /// <summary>
        /// Configures the rules for the controller.
        /// </summary>
        /// <param name="interactor">The Interactor associated with the controller.</param>
        /// <param name="ruleList">The rule to manage.</param>
        protected virtual void ConfigureControllerRules(InteractorFacade interactor, ListContainsRule ruleList)
        {
            if (interactor == null || ruleList == null)
            {
                return;
            }

            ruleList.Objects.Clear();
            ruleList.Objects.Add(interactor.gameObject);
        }

        /// <summary>
        /// Updates the <see cref="HapticPulser.Intensity"/> on the given <see cref="HapticProcess"/>.
        /// </summary>
        /// <param name="process">The process to update</param>
        /// <returns>the original Intensity value to restore.</returns>
        protected virtual float? UpdateIntensity(HapticProcess process)
        {
            float? cachedIntensity = null;
            HapticPulser pulser = process as HapticPulser;

            if (pulser != null)
            {
                cachedIntensity = pulser.Intensity;
                pulser.Intensity = Facade.Intensity;
            }

            return cachedIntensity;
        }

        /// <summary>
        /// Resets the <see cref="HapticPulser.Intensity"/> to the given value.
        /// </summary>
        /// <param name="process">The process to update.</param>
        /// <param name="value">The value to set the Intensity to.</param>
        protected virtual void ResetIntensity(HapticProcess process, float? value)
        {
            HapticPulser pulser = process as HapticPulser;

            if (pulser != null && value != null)
            {
                pulser.Intensity = (float)value;
            }
        }
    }
}