using Seville;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
namespace InstalasiIoT
{
    public class CableValidator : MonoBehaviour
    {
        private SESocketInteractor socketComponent;
        public SESocketInteractor otherPairSocket;
        [SerializeField] private SocketScoreChecker socketScoreChecker;
        private BoneCableController boneCableController;
        private void Start()
        {
            socketComponent = GetComponent<SESocketInteractor>();
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
                    socketScoreChecker.FinishQuest();
                    socketScoreChecker.SetStatus(Status.Connected);
                }
                else if (cableController.sockets.Count > 0 && !cableController.sockets.Contains(otherPairSocket))
                {
                    socketScoreChecker.SetStatus(Status.Error);
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
            }
        }
    }
}
