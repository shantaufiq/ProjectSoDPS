using Sandbox;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
namespace InstalasiIoT
{
    public class CableValidator : MonoBehaviour
    {
        private SocketInteractorTwoAttach socketComponent;
        public SocketInteractorTwoAttach[] otherPairSockets;
        [SerializeField] private PinType pinSocketType;
        [SerializeField] private SocketScoreChecker[] socketScoreChecker;
        private BoneCableController boneCableController;

        private void Start()
        {
            socketComponent = GetComponent<SocketInteractorTwoAttach>();
        }

        public void CheckCable()
        {
            var obj = socketComponent.GetOldestInteractableSelected();
            if (obj.transform.gameObject.TryGetComponent<BoneCableController>(out var boneCable))
            {
                boneCableController = boneCable;
                var cableController = boneCableController.CableController;
                cableController.sockets.Add(socketComponent);
                cableController.socketsType.Add(pinSocketType);

                if (cableController.sockets.Any(socket => otherPairSockets.Contains(socket)))
                {
                    var scoreChecker = GetScoreChecker(cableController);

                    scoreChecker.isQuestFinish = true;
                    scoreChecker.ValidateQuest();

                    foreach (var type in cableController.socketsType)
                    {
                        if (type == cableController.supposedPinConnect)
                        {
                            scoreChecker.SetStatus(Status.Connected);
                        }
                        else
                        {
                            scoreChecker.SetStatus(Status.Warning);
                            break;
                        }
                    }

                   /* if (cableController.socketsType.Contains(pinSocketType))
                    {
                        scoreChecker.SetStatus(Status.Connected);
                    }
                    else
                    {
                        scoreChecker.SetStatus(Status.Warning);
                    }*/

                }
                else if (/*cableController.sockets.Count > 0 &&*/
                    !cableController.sockets.Any(socket => otherPairSockets.Contains(socket)))
                {
                    var scoreChecker = GetScoreChecker(cableController);

                    scoreChecker.SetStatus(Status.Error);
                    scoreChecker.isQuestFinish = false;
                }

            }
        }

        private SocketScoreChecker GetScoreChecker(CableController cableController)
        {
            var scoreChecker = new SocketScoreChecker();
            foreach (var socket in cableController.sockets)
            {
                var matchingSocket = socketScoreChecker.FirstOrDefault(scoreChecker => scoreChecker.identitySocket == socket);
                if (matchingSocket != null)
                {
                    scoreChecker = matchingSocket;
                    break;
                }
            }
            return scoreChecker;
        }

        public void Detach()
        {
            if (boneCableController == null) return;
            var cableController = boneCableController.CableController;
            if (cableController.sockets.Count > 0)
            {
                var scoreChecker = GetScoreChecker(cableController);
                cableController.sockets.Remove(socketComponent);
                cableController.socketsType.Remove(pinSocketType);
                scoreChecker.SetStatus(Status.Error);
                if (scoreChecker.isQuestFinish)
                {
                    scoreChecker.isQuestFinish = false;
                    scoreChecker.ValidateQuest();
                }
            }
        }
    }

    public enum PinType
    {
        DataPin,
        GroundPin,
        PowerPin
    }
}
