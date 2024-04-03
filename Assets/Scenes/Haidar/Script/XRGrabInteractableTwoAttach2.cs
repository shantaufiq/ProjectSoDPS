using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

    public class XRGrabInteractableTwoAttach2 : XRGrabInteractable
    {
        public string objName;
        public Transform rightAttachTransform;
        public Transform leftAttachTransform;

        private Rigidbody rb;


        protected override void Awake()
        {
            base.Awake();
            rb = GetComponent<Rigidbody>();
        }

        public override Transform GetAttachTransform(IXRInteractor interactor)
        {
            Transform attachTransform = null;

            if (interactor.transform.CompareTag("Left Hand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (interactor.transform.CompareTag("Right Hand"))
            {
                attachTransform = rightAttachTransform;
            }

            return attachTransform != null ? attachTransform : base.GetAttachTransform(interactor);
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            rb.constraints = RigidbodyConstraints.None;
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);

            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

    }
