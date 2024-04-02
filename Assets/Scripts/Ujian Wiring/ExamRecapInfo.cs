using InstalasiIoT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamRecapInfo : ConnectionStatus
{
    [Tooltip("If all quest is complete and user want to see feedback, this object will go to this targetPosition")]
    [SerializeField] private Transform targetPosition;

    public override void SetStatus(Status status)
    {
      /*  test = true;*/
    }
}
