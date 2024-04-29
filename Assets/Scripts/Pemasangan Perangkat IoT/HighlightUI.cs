using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace InstalasiIoT
{
    public class HighlightUI : MonoBehaviour
    {
        public enum AnimateTarget
        {
            Left,
            Right,
            Top,
            Bottom
        }

        [System.Serializable]
        public struct HighlightData
        {
            public Sprite imageDisplayBackground;
            [Space]
            public bool useArrow;
            public Vector3 arrowPosition;
            public Vector3 arrowRotation;
            public Vector2 arrowSize;
            public bool useAnimate;
            public AnimateTarget moveTarget;
            public Sprite pointerImage;
            public Vector3 pointerPosition;
            public Vector2 pointerSize;

            [Space]
            public bool useButton;
            public string buttonText;
            public Sprite buttonSprite;
            public Vector3 buttonPosition;
            public Vector2 buttonSize;
            [Space]
            public bool useBorder;
            public Vector3 borderPosition;
            public Vector2 borderSize;
        }

        [SerializeField] private List<HighlightData> highlightDatas;
        [Header("Init Component")]
        [SerializeField] private GameObject displayBackground;
        private Image backgroundImage;
        [SerializeField] private GameObject pointer;
        private Image pointerImage;
        private RectTransform pointerTransform;
        [SerializeField] private GameObject pointerArrow;
        private RectTransform pointerArrowTransform;
        [SerializeField] private GameObject button;
        [SerializeField] private TextMeshProUGUI buttonTMP;
        private Image buttonImage;
        private RectTransform buttonTransform;
        [SerializeField] private GameObject borderGameobject;
        private RectTransform borderTransform;

        [Header("Pointer animate config")]
        public float moveDistance = 100f;
        public float animationSpeed = 0.5f;

        private Vector2 originalPosition;
        private bool moving = true;

        private int currentIndex = 0;
        private Vector2 targetArrowMove;

        [SerializeField] private UnityEvent onHighlightFinish;

        private void Start()
        {
            backgroundImage = displayBackground.GetComponent<Image>();
            pointerTransform = pointer.GetComponent<RectTransform>();
            pointerImage = pointer.GetComponent<Image>();
            pointerArrowTransform = pointerArrow.GetComponent<RectTransform>();
            buttonTransform = button.GetComponent<RectTransform>();
            buttonImage = button.GetComponent<Image>();
            borderTransform = borderGameobject.GetComponent<RectTransform>();
            NextHighlight();
        }

        private void NextHighlight()
        {
            if (highlightDatas.Count > 0)
            {
                HighlightData data = highlightDatas[currentIndex];
                backgroundImage.sprite = data.imageDisplayBackground;

                pointerImage.sprite = data.pointerImage;
                pointerTransform.anchoredPosition = data.pointerPosition;
                pointerTransform.sizeDelta = data.pointerSize;
                pointer.SetActive(true);
                targetArrowMove = TargetMoveInit(data.moveTarget);
                if (data.useArrow)
                {
                    pointerArrowTransform.anchoredPosition = data.arrowPosition;
                    pointerArrowTransform.localEulerAngles = data.arrowRotation;
                    pointerArrow.SetActive(true);
                }
                else
                {
                    pointerArrow.SetActive(false);
                }

                originalPosition = pointerTransform.anchoredPosition;
                if (data.useAnimate) AnimatePointer();

                if (data.useButton)
                {
                    buttonTransform.anchoredPosition = data.buttonPosition;
                    buttonTransform.sizeDelta = data.buttonSize;
                    buttonImage.sprite = data.buttonSprite;
                    button.SetActive(true);
                    buttonTMP.text = data.buttonText;

                }
                else
                {
                    button.SetActive(false);
                }

                if (data.useBorder)
                {
                    borderTransform.anchoredPosition = data.borderPosition;
                    borderTransform.sizeDelta = data.borderSize;
                    borderGameobject.SetActive(false);
                    borderGameobject.SetActive(true);
                }
                else
                {
                    borderGameobject.SetActive(false);
                }

                
                if (currentIndex == (highlightDatas.Count - 1))
                {
                    onHighlightFinish?.Invoke();
                }
            }
        }

        public void OnButtonClick()
        {
            currentIndex = (currentIndex + 1) % highlightDatas.Count;
            Debug.Log(currentIndex);
            LeanTween.cancelAll();
            NextHighlight();
        }

        private Vector2 TargetMoveInit(AnimateTarget target)
        {
            var targetMove = Vector2.zero;
            switch (target)
            {
                case AnimateTarget.Left:
                    targetMove = Vector2.left * moveDistance;
                    break;
                case AnimateTarget.Right:
                    targetMove = Vector2.right * moveDistance;
                    break;
                case AnimateTarget.Top:
                    targetMove = Vector2.up * moveDistance;
                    break;
                case AnimateTarget.Bottom:
                    targetMove = Vector2.down * moveDistance;
                    break;
            }
            return targetMove;
        }

        private void AnimatePointer()
        {
            if (moving)
            {
                LeanTween.move(pointerTransform, originalPosition + targetArrowMove, animationSpeed)
                    .setEaseInOutSine()
                    .setOnComplete(AnimateBack);
            }
            else
            {
                LeanTween.move(pointerTransform, originalPosition, animationSpeed)
                    .setEaseInOutSine()
                    .setOnComplete(AnimatePointer);
            }

            moving = !moving;
        }

        private void AnimateBack()
        {
            LeanTween.move(pointerTransform, originalPosition, animationSpeed)
                .setEaseInOutSine()
                .setOnComplete(AnimatePointer);
        }

    }
}
