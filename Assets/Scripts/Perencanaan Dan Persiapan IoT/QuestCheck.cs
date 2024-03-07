using UnityEngine;
using System.Collections.Generic;
using Tproject.Quest;

namespace PerencanaanPersiapanIoT
{
    public class QuestCheck : MonoBehaviour
    {
        private bool isQuestCompleted = false;
        private string objectName = "";
        [SerializeField] private List<QuestPicker> questList;

        public ToDoController toDoController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Object") && !isQuestCompleted)
            {
                objectName = other.gameObject.name;
                CheckQuestCompletion();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Object") && !isQuestCompleted)
            {
                objectName = other.gameObject.name;
                CheckQuestCompletion();
            }
        }

        private void CheckQuestCompletion()
        {
            bool foundMatchingQuest = false;
            foreach (QuestPicker quest in questList)
            {
                if (quest.objectName == objectName)
                {
                    Debug.Log("Barang dengan nama " + objectName + " cocok dengan quest yang telah selesai.");

                    foundMatchingQuest = true;
                    toDoController.FinishItem(quest.questNumber);

                    // Menandai quest sebagai selesai
                    isQuestCompleted = true;

                    break;
                }
            }

            if (!foundMatchingQuest)
            {
                Debug.Log("Barang dengan nama " + objectName + " tidak cocok dengan quest yang telah selesai.");
            }
        }
        
    }

    [System.Serializable]
    public struct QuestPicker
    {
        public string objectName;
        public int questNumber;
        public bool isDone; // Menambahkan variabel untuk menandai apakah quest sudah selesai atau tidak
    }
}
