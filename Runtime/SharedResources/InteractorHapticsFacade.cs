namespace Tilia.Output.InteractorHaptics
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.CameraRigs.TrackedAlias;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.XR;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// The public interface into the Interactor Haptics Prefab.
    /// </summary>
    public class InteractorHapticsFacade : MonoBehaviour
    {
        #region Link Settings
        /// <summary>
        /// The linked <see cref="TrackedAliasFacade"/>.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Link Settings"), DocumentedByXml]
        public TrackedAliasFacade TrackedAlias { get; set; }
        /// <summary>
        /// The linked <see cref="InteractorFacade"/> to relate to the left controller.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public InteractorFacade LeftInteractor { get; set; }
        /// <summary>
        /// The linked <see cref="InteractorFacade"/> to relate to the right controller.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public InteractorFacade RightInteractor { get; set; }
        #endregion

        #region Haptic Settings
        /// <summary>
        /// The intensity to produce the haptic output at for the current process.
        /// </summary>
        [Serialized]
        [field: Header("Haptic Settings"), DocumentedByXml]
        public float Intensity { get; set; } = 1f;
        /// <summary>
        /// The haptic profile to process.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public int Profile { get; set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The linked <see cref="InteractorHapticsConfigurator"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public InteractorHapticsConfigurator Configuration { get; protected set; }
        #endregion

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
        [CalledAfterChangeOf(nameof(LeftInteractor))]
        protected virtual void OnAfterLeftInteractorChange()
        {
            Configuration.ConfigureLeftControllerRules();
        }

        /// <summary>
        /// Called after <see cref="RightInteractor"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(RightInteractor))]
        protected virtual void OnAfterRightInteractorChange()
        {
            Configuration.ConfigureRightControllerRules();
        }
    }
}