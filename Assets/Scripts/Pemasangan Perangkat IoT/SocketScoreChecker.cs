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

        public void FinishQuest()
        {
            StartCoroutine(ValidateQuest());
        }

        private IEnumerator ValidateQuest()
        {
            _partialQuestController.FinishItem(questIndex);
            yield return new WaitForSeconds(1f);
  /*          foreach (var obj in sockets)
            {
                obj.GetOldestInteractableSelected().transform.gameObject.GetComponent<XRGrabInteractableTwoAttach>().interactionLayers = LayerMask.GetMask("Nothing");
            }*/

        }

    }
}
