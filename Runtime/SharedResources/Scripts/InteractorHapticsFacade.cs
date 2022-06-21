namespace Tilia.Output.InteractorHaptics
{
    using Tilia.CameraRigs.TrackedAlias;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.XR;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;

    /// <summary>
    /// The public interface into the Interactor Haptics Prefab.
    /// </summary>
    public class InteractorHapticsFacade : MonoBehaviour
    {
        #region Link Settings
        [Header("Link Settings")]
        [Tooltip("The linked TrackedAliasFacade.")]
        [SerializeField]
        private TrackedAliasFacade trackedAlias;
        /// <summary>
        /// The linked <see cref="TrackedAliasFacade"/>.
        /// </summary>
        public TrackedAliasFacade TrackedAlias
        {
            get
            {
                return trackedAlias;
            }
            set
            {
                trackedAlias = value;
            }
        }
        [Tooltip("The linked InteractorFacade to relate to the left controller.")]
        [SerializeField]
        private InteractorFacade leftInteractor;
        /// <summary>
        /// The linked <see cref="InteractorFacade"/> to relate to the left controller.
        /// </summary>
        public InteractorFacade LeftInteractor
        {
            get
            {
                return leftInteractor;
            }
            set
            {
                leftInteractor = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterLeftInteractorChange();
                }
            }
        }
        [Tooltip("The linked InteractorFacade to relate to the right controller.")]
        [SerializeField]
        private InteractorFacade rightInteractor;
        /// <summary>
        /// The linked <see cref="InteractorFacade"/> to relate to the right controller.
        /// </summary>
        public InteractorFacade RightInteractor
        {
            get
            {
                return rightInteractor;
            }
            set
            {
                rightInteractor = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterRightInteractorChange();
                }
            }
        }
        #endregion

        #region Haptic Settings
        [Header("Haptic Settings")]
        [Tooltip("The intensity to produce the haptic output at for the current process.")]
        [SerializeField]
        [Range(0f, 1f)]
        private float intensity = 1f;
        /// <summary>
        /// The intensity to produce the haptic output at for the current process.
        /// </summary>
        public float Intensity
        {
            get
            {
                return intensity;
            }
            set
            {
                intensity = value;
            }
        }
        [Tooltip("The haptic profile to process.")]
        [SerializeField]
        private int profile;
        /// <summary>
        /// The haptic profile to process.
        /// </summary>
        public int Profile
        {
            get
            {
                return profile;
            }
            set
            {
                profile = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The InteractorFacade that has been queued up to perform haptics on in the future.")]
        [SerializeField]
        private InteractorFacade queuedInteractor;
        /// <summary>
        /// The <see cref="InteractorFacade"/> that has been queued up to perform haptics on in the future.
        /// </summary>
        public InteractorFacade QueuedInteractor
        {
            get
            {
                return queuedInteractor;
            }
            set
            {
                queuedInteractor = value;

            }
        }


        [Tooltip("The linked InteractorHapticsConfigurator.")]
        [SerializeField]
        [Restricted]
        private InteractorHapticsConfigurator configuration;
        /// <summary>
        /// The linked <see cref="InteractorHapticsConfigurator"/>.
        /// </summary>
        public InteractorHapticsConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            protected set
            {
                configuration = value;
            }
        }
        #endregion

        /// <summary>
        /// Clears <see cref="TrackedAlias"/>.
        /// </summary>
        public virtual void ClearTrackedAlias()
        {
            if (!this.IsValidState())
            {
                return;
            }

            TrackedAlias = default;
        }

        /// <summary>
        /// Clears <see cref="LeftInteractor"/>.
        /// </summary>
        public virtual void ClearLeftInteractor()
        {
            if (!this.IsValidState())
            {
                return;
            }

            LeftInteractor = default;
        }

        /// <summary>
        /// Clears <see cref="RightInteractor"/>.
        /// </summary>
        public virtual void ClearRightInteractor()
        {
            if (!this.IsValidState())
            {
                return;
            }

            RightInteractor = default;
        }

        /// <summary>
        /// Clears <see cref="QueuedInteractor"/>.
        /// </summary>
        public virtual void ClearQueuedInteractor()
        {
            if (!this.IsValidState())
            {
                return;
            }

            CancelHapticsOnQueued();
            QueuedInteractor = default;
        }

        /// <summary>
        /// Performs the haptics process on the default haptic process associated with the queued Interactor.
        /// </summary>
        public virtual void PerformDefaultHapticsOnQueued()
        {
            if (QueuedInteractor == null)
            {
                return;
            }

            PerformDefaultHaptics(QueuedInteractor);
        }

        /// <summary>
        /// Performs the haptics process on the default haptic process associated with the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to process the haptics for.</param>
        public virtual void PerformDefaultHaptics(InteractorFacade interactor)
        {
            Configuration.ProcessDefaultHapticsOnMatch(interactor.gameObject);
        }

        /// <summary>
        /// Performs the haptics process on the default haptic process associated with the given Interactor <see cref="GameObject"/>.
        /// </summary>
        /// <param name="interactor">The Interactor to process the haptics for.</param>
        public virtual void PerformDefaultHaptics(GameObject interactor)
        {
            Configuration.ProcessDefaultHapticsOnMatch(interactor);
        }

        /// <summary>
        /// Performs the haptics process on the default haptic process associated with the Interactor associated with the specified <see cref="XRNode"/>.
        /// </summary>
        /// <param name="node">The node associated with the Interactor to process the haptics for.</param>
        public virtual void PerformDefaultHaptics(XRNode node)
        {
            switch (node)
            {
                case XRNode.LeftHand:
                    Configuration.BeginDefaultHapticsOnLeftController();
                    break;
                case XRNode.RightHand:
                    Configuration.BeginDefaultHapticsOnRightController();
                    break;
            }
        }

        /// <summary>
        /// Performs the haptics process on the specified haptic profile associated with the queued Interactor.
        /// </summary>
        public virtual void PerformProfileHapticsOnQueued()
        {
            if (QueuedInteractor == null)
            {
                return;
            }

            PerformProfileHaptics(QueuedInteractor);
        }

        /// <summary>
        /// Performs the haptics process on the specified haptic profile associated with the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to process the haptics for.</param>
        public virtual void PerformProfileHaptics(InteractorFacade interactor)
        {
            Configuration.ProcessProfileHapticsOnMatch(interactor.gameObject);
        }

        /// <summary>
        /// Performs the haptics process on the specified haptic profile associated with the given Interactor <see cref="GameObject"/>.
        /// </summary>
        /// <param name="interactor">The Interactor to process the haptics for.</param>
        public virtual void PerformProfileHaptics(GameObject interactor)
        {
            Configuration.ProcessProfileHapticsOnMatch(interactor);
        }

        /// <summary>
        /// Performs the haptics process on the specified haptic profile associated with the Interactor associated with the specified <see cref="XRNode"/>.
        /// </summary>
        /// <param name="node">The node associated with the Interactor to process the haptics for.</param>
        public virtual void PerformProfileHaptics(XRNode node)
        {
            switch (node)
            {
                case XRNode.LeftHand:
                    Configuration.BeginProfileHapticsOnLeftController();
                    break;
                case XRNode.RightHand:
                    Configuration.BeginProfileHapticsOnRightController();
                    break;
            }
        }

        /// <summary>
        /// Cancels all haptic processes associated with the queued Interactor.
        /// </summary>
        public virtual void CancelHapticsOnQueued()
        {
            if (QueuedInteractor == null)
            {
                return;
            }

            CancelHaptics(QueuedInteractor);
        }

        /// <summary>
        /// Cancels all haptic processes associated with the given Interactor.
        /// </summary>
        /// <param name="interactor">The Interactor to cancel the haptics on.</param>
        public virtual void CancelHaptics(InteractorFacade interactor)
        {
            Configuration.ProcessCancelHapticsOnMatch(interactor.gameObject);
        }

        /// <summary>
        /// Cancels all haptic processes associated with the given Interactor <see cref="GameObject"/>.
        /// </summary>
        /// <param name="interactor">The Interactor to cancel the haptics on.</param>
        public virtual void CancelHaptics(GameObject interactor)
        {
            Configuration.ProcessCancelHapticsOnMatch(interactor);
        }

        /// <summary>
        /// Cancels all haptic processes associated with the Interactor associated with the specified <see cref="XRNode"/>.
        /// </summary>
        /// <param name="node">The node associated with the Interactor to cancel the haptics on.</param>
        public virtual void CancelHaptics(XRNode node)
        {
            switch (node)
            {
                case XRNode.LeftHand:
                    Configuration.CancelHapticsOnLeftController();
                    break;
                case XRNode.RightHand:
                    Configuration.CancelHapticsOnRightController();
                    break;
            }
        }

        /// <summary>
        /// Cancels all haptic processes for both controllers.
        /// </summary>
        public virtual void CancelAllHaptics()
        {
            Configuration.CancelHapticsOnLeftController();
            Configuration.CancelHapticsOnRightController();
        }

        /// <summary>
        /// Called after <see cref="LeftInteractor"/> has been changed.
        /// </summary>
        protected virtual void OnAfterLeftInteractorChange()
        {
            Configuration.ConfigureLeftControllerRules();
        }

        /// <summary>
        /// Called after <see cref="RightInteractor"/> has been changed.
        /// </summary>
        protected virtual void OnAfterRightInteractorChange()
        {
            Configuration.ConfigureRightControllerRules();
        }
    }
}