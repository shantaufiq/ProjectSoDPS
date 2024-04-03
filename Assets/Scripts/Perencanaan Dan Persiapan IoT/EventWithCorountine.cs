using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EventWithCoroutine : MonoBehaviour
{
    public UnityEvent whatToDo;
    public float delay;

    public void DoEvent()
    {
        StartCoroutine(EventToDo());
    }

    private IEnumerator EventToDo()
    {
        yield return new WaitForSeconds(delay);
        whatToDo.Invoke();
    }
}
