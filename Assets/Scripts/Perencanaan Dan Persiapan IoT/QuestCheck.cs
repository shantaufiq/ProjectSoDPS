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
        private GameObject canvasObject; // Mengubah menjadi private karena akan diakses melalui transform parent

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Object") && !isQuestCompleted)
        //    {
        //        objectName = other.gameObject.name;
        //        canvasObject = FindCanvasInParent(other.gameObject);
        //        CheckQuestCompletion();
        //    }
        //}

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Object"))
            {
                // Reset objectName and canvasObject when object exits the trigger
                objectName = "";
                canvasObject = null;
                isQuestCompleted = false; // Set isQuestCompleted to false when the object exits the trigger
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Object") && !isQuestCompleted)
            {
                objectName = other.gameObject.name;
                canvasObject = FindCanvasInParent(other.gameObject);
                CheckQuestCompletion();
                
            }
        }

        private GameObject FindCanvasInParent(GameObject parentObject)
        {
            // Mencari objek canvas dalam parent
            Canvas canvas = parentObject.GetComponentInChildren<Canvas>();
            if (canvas != null)
            {
                return canvas.gameObject;
            }
            return null;
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

                    // Menonaktifkan canvas
                    if (canvasObject != null)
                    {
                        canvasObject.SetActive(false);
                    }

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
