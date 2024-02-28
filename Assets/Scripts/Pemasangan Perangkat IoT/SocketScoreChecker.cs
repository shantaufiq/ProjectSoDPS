using Seville;
using System.Collections;
using Tproject.Quest;
using UnityEngine;

namespace InstalasiIoT
{
    public class SocketScoreChecker : MonoBehaviour
    {
        public int targetScore;
        [SerializeField] private int questIndex;
        [SerializeField] private PartialQuestController _partialQuestController;
        [SerializeField] private XRGrabInteractableTwoAttach[] objectInteractables;
        private int _currentScore;
        private bool _isQuestFinished;

        public bool Success()
        {
            if (_isQuestFinished)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddScore()
        {
            _currentScore++;
            StartCoroutine(ValidateQuest());
        }

        public void RemoveScore()
        {
            _currentScore--;
        }

        private IEnumerator ValidateQuest()
        {
            if (_currentScore >= targetScore)
            {
                _partialQuestController.FinishItem(questIndex);
                yield return new WaitForSeconds(0.5f);
                foreach (var obj in objectInteractables)
                {
                    obj.enabled = false;
                }
            }
        }

    }
}
