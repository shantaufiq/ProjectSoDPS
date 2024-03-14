using Sandbox;
using Seville;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
namespace InstalasiIoT
{
    public class CableValidator : MonoBehaviour
    {
        private SocketInteractorTwoAttach socketComponent;
        public SocketInteractorTwoAttach otherPairSocket;
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

                if (cableController.sockets.Contains(otherPairSocket))
                {
                    socketScoreChecker.isQuestFinish = true;
                    socketScoreChecker.ValidateQuest();
                    socketScoreChecker.SetStatus(Status.Connected);
                }
                else if (cableController.sockets.Count > 0 && !cableController.sockets.Contains(otherPairSocket))
                {
                    socketScoreChecker.SetStatus(Status.Error);
                    socketScoreChecker.isQuestFinish = false;
                }
                cableController.sockets.Add(socketComponent);

            }
        }

        public void Detach()
        {
            if (boneCableController == null) return;
            var cableController = boneCableController.CableController;
            if (cableController.sockets.Count > 0)
            {
                cableController.sockets.Remove(socketComponent);
                socketScoreChecker.SetStatus(Status.Error);
                if (socketScoreChecker.isQuestFinish)
                {
                    socketScoreChecker.isQuestFinish = false;
                    socketScoreChecker.ValidateQuest();
                }
            }
        }
    }
}
