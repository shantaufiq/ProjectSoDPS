using UnityEngine.UI;
using UnityEngine;

namespace Sandbox
{
    public class AnimatePingpong : MonoBehaviour
    {

        public enum MovementType
        {
            LeftToRight, RightToLeft, UpToDown, DownToUp, none
        }

        public MovementType defaultMovement;
        public GameObject targetObject;

        private int _animationId;

        // public Sprite spriteExample;

        private void Awake()
        {
            this.transform.GetComponent<Image>().enabled = false;
        }

        void Start()
        {
            // SetDescriptionBtn(spriteExample, new Vector3(150, 42, 0), defaultMovement);
        }

        public void SetDescriptionBtn(Sprite _img, Vector3 _transform, MovementType _type)
        {
            this.transform.localPosition = _transform;
            targetObject.GetComponentInChildren<Image>().sprite = _img;
            targetObject.transform.localPosition = Vector3.zero;

            PingpongObject(_type, .7f);
        }

        public void PingpongObject(MovementType _movementType, float _time)
        {
            if (_movementType == MovementType.RightToLeft)
            {
                targetObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                int i = LeanTween.moveLocalX(targetObject, 20f, _time).setEaseInQuad().setLoopPingPong().id;
                _animationId = i;
            }
            else if (_movementType == MovementType.LeftToRight)
            {
                targetObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                int i = LeanTween.moveLocalX(targetObject, -20f, _time).setEaseInQuad().setLoopPingPong().id;
                _animationId = i;
            }
            else if (_movementType == MovementType.DownToUp)
            {
                targetObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                int i = LeanTween.moveLocalY(targetObject, 20f, _time).setEaseInQuad().setLoopPingPong().id;
                _animationId = i;
            }
            else if (_movementType == MovementType.UpToDown)
            {
                targetObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                int i = LeanTween.moveLocalY(targetObject, 20f, _time).setEaseInQuad().setLoopPingPong().id;
                _animationId = i;
            }
        }

        public void StopAnimate()
        {
            LeanTween.cancel(_animationId);
            targetObject.transform.localPosition = Vector3.zero;
        }
    }
}