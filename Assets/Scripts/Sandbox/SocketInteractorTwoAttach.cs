using Seville;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Sandbox
{
    public class SocketInteractorTwoAttach : XRSocketInteractor
    {
        [Header("Framework Settings")]
        [Tooltip("can be used to store the first attach position")]
        public Transform targetAttach1;
        [Tooltip("can be used to store the second attach position")]
        public Transform targetAttach2;

        [Space]
        public Transform parentArea;

        [Tooltip("make sure you have set objName on XRGrabIntractableTwoAttach")]
        public List<string> targetObjNames = new List<string>();
        private MeshRenderer mesh;

        protected override void Awake()
        {
            base.Awake();
            mesh = GetComponent<MeshRenderer>();
            if (attachTransform != null) attachTransform = null;
        }

        [System.Obsolete]
        protected override void OnSelectEntered(XRBaseInteractable interactable)
        {
            base.OnSelectEntered(interactable);

            if (interactable.gameObject.CompareTag("SocketAttach1")) attachTransform = targetAttach1;
            else if (interactable.gameObject.CompareTag("SocketAttach2")) attachTransform = targetAttach2;

            interactable.transform.SetParent(parentArea, false);
            ToggleMesh(false);

            var obj = interactable.GetComponent<XRGrabInteractableTwoAttach>();
            obj.retainTransformParent = false;
            interactable.transform.localPosition = attachTransform.position;
            interactable.transform.localRotation = attachTransform.rotation;
        }

        [System.Obsolete]
        protected override void OnSelectExited(XRBaseInteractable interactable)
        {
            base.OnSelectExited(interactable);

            ToggleMesh(true);
            var obj = interactable.GetComponent<XRGrabInteractableTwoAttach>();
            obj.retainTransformParent = true;
        }

        [System.Obsolete]
        protected override void OnHoverEntered(XRBaseInteractable interactable)
        {
            base.OnHoverEntered(interactable);
            if (this.GetOldestInteractableSelected() != null) return;
            if (interactable.gameObject.CompareTag("SocketAttach1")) attachTransform = targetAttach1;
            else if (interactable.gameObject.CompareTag("SocketAttach2")) attachTransform = targetAttach2;
            else attachTransform = null;

            ToggleMesh(false);
        }

        [System.Obsolete]
        protected override void OnHoverExited(XRBaseInteractable interactable)
        {
            base.OnHoverExited(interactable);

            if (this.GetOldestInteractableSelected() == null) attachTransform = null;

            ToggleMesh(true);
        }

        [System.Obsolete]
        public override bool CanHover(XRBaseInteractable interactable)
        {
            return base.CanHover(interactable) && MatchUsingTag(interactable);
        }

        [System.Obsolete]
        public override bool CanSelect(XRBaseInteractable interactable)
        {
            return base.CanSelect(interactable) && MatchUsingTag(interactable);
        }

        private bool MatchUsingTag(XRBaseInteractable interactable)
        {
            var obj = interactable.GetComponent<XRGrabInteractableTwoAttach>();

            return targetObjNames.Contains(obj.objName);
            // return interactable.CompareTag(targetTag);
        }

        private void ToggleMesh(bool state)
        {
            mesh.enabled = state;
        }
    }
}