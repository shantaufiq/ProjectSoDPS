using Sandbox;
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
        [SerializeField] private SocketScoreChecker socketScoreChecker;
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

                if (cableController.sockets.Any(socket => otherPairSockets.Contains(socket)))
                {
                    socketScoreChecker.isQuestFinish = true;
                    socketScoreChecker.ValidateQuest();
                    if (cableController.socketsType.Contains(pinSocketType))
                    {
                        socketScoreChecker.SetStatus(Status.Connected);
                    }
                    else
                    {
                        socketScoreChecker.SetStatus(Status.Warning);
                    }

                }
                else if (cableController.sockets.Count > 0 && 
                    !cableController.sockets.Any(socket => otherPairSockets.Contains(socket)))
                {
                    socketScoreChecker.SetStatus(Status.Error);
                    socketScoreChecker.isQuestFinish = false;
                }
                cableController.sockets.Add(socketComponent);
                cableController.socketsType.Add(pinSocketType);

            }
        }

        public void Detach()
        {
            if (boneCableController == null) return;
            var cableController = boneCableController.CableController;
            if (cableController.sockets.Count > 0)
            {
                cableController.sockets.Remove(socketComponent);
                cableController.socketsType.Remove(pinSocketType);
                socketScoreChecker.SetStatus(Status.Error);
                if (socketScoreChecker.isQuestFinish)
                {
                    socketScoreChecker.isQuestFinish = false;
                    socketScoreChecker.ValidateQuest();
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
