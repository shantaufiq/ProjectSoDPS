using Seville;
using System.Collections;
using Tproject.Quest;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace InstalasiIoT
{
    public class SocketScoreChecker : MonoBehaviour
    {
        [SerializeField] private int questIndex;
        [SerializeField] private PartialQuestController _partialQuestController;
        [SerializeField] private SESocketInteractor[] sockets;
        [SerializeField] private ConnectionStatus connectionStatus;
        private Status status;

        public void FinishQuest()
        {
            _partialQuestController.FinishItem(questIndex);
        }

        private void ValidateConnection(Status statusValue)
        {
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
