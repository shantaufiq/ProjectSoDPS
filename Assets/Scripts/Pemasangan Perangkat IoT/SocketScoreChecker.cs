using Seville;
using System;
using System.Collections;
using Tproject.Quest;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace InstalasiIoT
{
    public class SocketScoreChecker : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnQuestFinish;
        [SerializeField] private UnityEvent OnQuestFail;
        [SerializeField] private SESocketInteractor[] sockets;
        [SerializeField] private ConnectionStatus connectionStatus;
        public bool isQuestFinish;
        private Status status;

        public void ValidateQuest()
        {
            if (isQuestFinish)
            {
                OnQuestFinish?.Invoke();
            }
            else
            {
                OnQuestFail?.Invoke();
            }
            
        }

        private void ValidateConnection(Status statusValue)
        {
            if (connectionStatus == null) return;
            switch (statusValue)
            {
                case Status.Connected:
                    connectionStatus.SetStatus(Status.Connected);
                    break;
                case Status.Error:
                    connectionStatus.SetStatus(Status.Error);
                    break;
            }
        }

        public void SetStatus(Status statusValue)
        {
            status = statusValue;
            ValidateConnection(status);
        }
    }
}
