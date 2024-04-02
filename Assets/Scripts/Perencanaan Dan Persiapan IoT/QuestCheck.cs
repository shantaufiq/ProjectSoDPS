using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace PerencanaanPersiapanIoT
{
    public class QuestCheck : MonoBehaviour
    {
        private bool isQuestCompleted = false;
        private string objectName = "";
        [SerializeField] private List<QuestPicker> questList;

        public ToDoController toDoController;
        private GameObject canvasObject; // Mengubah menjadi private karena akan diakses melalui transform parent

        private Renderer objectRenderer;
        private Color startColor;

        public List<Material> objectMaterials = new List<Material>(); // List untuk menyimpan semua material pada objek dan anaknya


        private void Start()
        {
            objectRenderer = GetComponent<Renderer>();
            startColor = objectRenderer.material.color;

            FindMaterialsRecursively(this.gameObject);
        }

        private void FindMaterialsRecursively(GameObject obj)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Jika objek memiliki komponen renderer, tambahkan semua materialnya ke dalam list
                foreach (Material material in renderer.materials)
                {
                    objectMaterials.Add(material);
                }
            }

            // Cek semua anak objek
            foreach (Transform child in obj.transform)
            {
                FindMaterialsRecursively(child.gameObject);
            }
        }

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

        public void ChechNamaObject()
        {
            objectName = this.gameObject.name;
            canvasObject = FindCanvasInParent(this.gameObject);
            CheckQuestCompletion();
        }

        private GameObject FindCanvasInParent(GameObject parentObject)
        {
            
            Canvas canvas = parentObject.GetComponentInChildren<Canvas>();
            if (canvas != null)
            {
                return canvas.gameObject;
            }
            return null;
        }

        public void CheckQuestCompletion()
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

                    //// Menonaktifkan canvas
                    //if (canvasObject != null)
                    //{
                    //    canvasObject.SetActive(false);
                    //}

                    break;
                }
            }

            if (!foundMatchingQuest)
            {
                Debug.Log("Barang dengan nama " + objectName + " tidak cocok dengan quest yang telah selesai.");
            }
        }


        public void ObjectDisappear()
        {
            DestroyObject();
        }

        private void DestroyObject()
        {
            GameObject thisObject = this.gameObject;
            if (thisObject != null)
            {
                Destroy(thisObject);
            }
            else
            {
                Debug.Log("Object tidak tersedia");
            }
        }

        private void TransparancyObject()
        {
            LeanTween.alpha(this.gameObject,0,2);
            //// Tentukan alpha yang diinginkan, misalnya 0.5 untuk separuh transparan
            //float targetAlpha = 0.0f; // 0.0f untuk membuat objek sepenuhnya transparan, 1.0f untuk opak

            //// Atur alpha pada semua material yang telah ditemukan
            //foreach (Material material in objectMaterials)
            //{
            //    Color newColor = material.color;
            //    newColor.a = targetAlpha;
            //    material.color = newColor;
            //}
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
