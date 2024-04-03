using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaypointHandler : MonoBehaviour
{
    public enum Direction
    {
        up, down, left, right
    }

    public Direction direction;
    public Image target;
    public float targetPosition;
    public float duration;
    public LeanTweenType type;

    public void Start()
    {
        AnimateTarget();
    }

    public void AnimateTarget()
    {
        switch (direction) 
        {
            case Direction.up:
                LeanTween.moveY(target.rectTransform, targetPosition, duration).setEase(type).setLoopPingPong(); 
                break;
            case Direction.down:
                LeanTween.moveY(target.rectTransform, targetPosition, duration).setEase(type).setLoopPingPong();
                break;
            case Direction.left:
                LeanTween.moveX(target.rectTransform, targetPosition, duration).setEase(type).setLoopPingPong();
                break;
            case Direction.right:
                LeanTween.moveX(target.rectTransform, targetPosition, duration).setEase(type).setLoopPingPong();
                break;

        }
    }

    

}
