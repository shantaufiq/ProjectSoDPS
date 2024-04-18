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

        /*public GameObject detectionCube;*/

        private void Start()
        {
            socketComponent = GetComponent<SocketInteractorTwoAttach>();
            SocketQuestContainer.onConstraintDeactivate += CheckCable;
        }

        private void OnDestroy()
        {
            SocketQuestContainer.onConstraintDeactivate -= CheckCable;
        }

        public void CheckCable()
        {
            var obj = socketComponent.GetOldestInteractableSelected();
            if (obj == null) return;
            if (obj.transform.gameObject.TryGetComponent<BoneCableController>(out var boneCable))
            {
                boneCableController = boneCable;
                if (boneCableController.CableController == null) return;
                var cableController = boneCableController.CableController;
                cableController.sockets.Add(socketComponent);
                cableController.socketsType.Add(pinSocketType);

                // Check if there are any sockets that are connected via cable that are also contained in the otherPairSockets array
                if (cableController.sockets.Any(socket => otherPairSockets.Contains(socket)))
                {
                    if (!TryGetScoreChecker(cableController, out var scoreChecker)) return;
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

                }
                else if (!cableController.sockets.Any(socket => otherPairSockets.Contains(socket)))
                {
                    if (!TryGetScoreChecker(cableController, out var scoreChecker))
                    {
                        foreach (var quest in socketScoreChecker)
                        {
                            if (quest.isQuestFinish) continue;
                            quest.SetStatus(Status.Error);
                        }
                    }
                    else // this is for connecting the cable in other than ESP pins
                    {
                        scoreChecker.SetStatus(Status.Error);
                        scoreChecker.isQuestFinish = false;
                    }
                }

            }
        }

        /// <summary>
        /// This method will check and get if there is a score checker where its identitySocket is the same as the socket in the cable controller
        /// </summary>
        /// <param name="cableController"></param>
        /// <param name="scoreChecker"></param>
        /// <returns></returns>
        private bool TryGetScoreChecker(CableController cableController, out SocketScoreChecker scoreChecker)
        {
            scoreChecker = null;
            var valid = false;
            foreach (var socket in cableController.sockets)
            {
                var matchingSocket = socketScoreChecker.FirstOrDefault(checker => checker.identitySocket == socket);
                if (matchingSocket != null)
                {
                    scoreChecker = matchingSocket;
                    valid = true;
                    break;
                }
            }
            return valid;
        }


        public void Detach()
        {
            if (boneCableController == null || boneCableController.CableController == null) return;
            var cableController = boneCableController.CableController;
            if (cableController.sockets.Count > 0)
            {
                if (!TryGetScoreChecker(cableController, out var scoreChecker))
                {
                    if (socketScoreChecker.Length > 1)
                    {
                        foreach (var quest in socketScoreChecker)
                        {
                            if (quest.isQuestFinish) continue;
                            quest.SetStatus(Status.Error);
                            quest.isQuestFinish = false;
                        }
                    }
                }
                else
                {
                    scoreChecker.SetStatus(Status.Error);
                    if (scoreChecker.isQuestFinish)
                    {
                        scoreChecker.isQuestFinish = false;
                        scoreChecker.ValidateQuest();
                    }
                }
                cableController.sockets.Remove(socketComponent);
                cableController.socketsType.Remove(pinSocketType);
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
