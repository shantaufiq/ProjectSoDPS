using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class SocketQuestContainer : MonoBehaviour
    {
        [SerializeField] private SocketScoreChecker[] socketScoreCheckers;

        [Tooltip("Activate this to prevent a quest from being completed without certain Condition")]
        [SerializeField] private bool useConstraint = false;
        public static Action onConstraintDeactivate = null;

        private void Start()
        {
            CheckConstraintActivation(useConstraint);
        }

        public void CheckConstraintActivation(bool value)
        {
            foreach (var socketScoreChecker in socketScoreCheckers)
            {
                socketScoreChecker.UseConstraint = value;
            }

            if (!value)
            {
                onConstraintDeactivate?.Invoke();
                Debug.Log("Constraint Deactivated");
            }
        }

    }
}
