using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class SignHandler : MonoBehaviour
{

    public Image signRectTransform; // Gunakan RectTransform untuk UI

    private LTDescr tween;
    public LeanTweenType easeType;

    public float moveY;
    public float setTime;

    public bool objectGrabbedPlayer;
    private bool isTweening = false; // Menyimpan status tweener saat ini

    private void Start()
    {
        objectGrabbedPlayer = false;
    }

    private void Update()
    {
        ObjectGrabbed();
    }

    public void trueGrabb()
    {
        objectGrabbedPlayer = true;
    }

    public void falseGrabb()
    {
        objectGrabbedPlayer = false;
    }

    public void Matikan()
    {
        signRectTransform.enabled = false;
        //LeanTween.cancel(tween.id);
        isTweening = false; // Set tweener telah dibatalkan
    }

    public void ObjectGrabbed()
    {
        if (objectGrabbedPlayer && !isTweening) // Hanya mulai tween jika belum ada tweener yang berjalan
        {
            signRectTransform.enabled = true;
            tween = LeanTween.moveY(signRectTransform.rectTransform, moveY, setTime).setLoopPingPong().setEase(easeType);
            isTweening = true; // Set tweener sedang berjalan
        }
        else if (!objectGrabbedPlayer && isTweening) // Hanya membatalkan tween jika ada tweener yang berjalan
        {
            signRectTransform.enabled = false;
            LeanTween.cancel(tween.id);
            isTweening = false; // Set tweener telah dibatalkan
        }
    }


}

