using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

namespace PerencanaanPersiapanIoT
{
    public class ToDoController : MonoBehaviour
    {
        [System.Serializable]
        public struct ItemList
        {
            public string itemName;
            public bool isCompleted; // Menyimpan status quest
        }

        public List<ItemList> itemLists;
        public ToDoHandler prefabQuest;
        public Transform itemListParent;
        public UnityEvent OnQuestFinished;

        private bool questFinishedEventFired = false;

        void Start()
        {
            DisplayItemList();
        }


        void DisplayItemList()
        {
            EraseCanvas();
            foreach (var item in itemLists)
            {
                ToDoHandler questItem = Instantiate(prefabQuest, itemListParent);
                questItem.SetToDoHandler(item.isCompleted, item.itemName);
            }

        }

        public void EraseCanvas()
        {
            for (int child = 0; child < itemListParent.childCount; child++)
            {
                Destroy(itemListParent.transform.GetChild(child).gameObject);
            }
        }

        public void FinishItem(int index)
        {
            var questData = itemLists;

            if (index > questData.Count - 1)
            {
                return;
            }

            if (!questData[index].isCompleted)
            {
                var temp = questData[index];
                temp.isCompleted = true;

                questData[index] = temp;
            }

            if (!questFinishedEventFired && itemLists.All(item => item.isCompleted))
            {
                questFinishedEventFired = true;
                OnQuestFinished.Invoke();
            }


            DisplayItemList();
        }
    }
}
