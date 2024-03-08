using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace PerencanaanPersiapanIoT
{
    public class ToDoHandler : MonoBehaviour
    {
        public Image ChecklistIMG;
        public TextMeshProUGUI toDoText;

        public Sprite trueSprite;
        public Sprite falseSprite;


        public void SetToDoHandler(bool status, string text)
        {
            if (status)
            {
                ChecklistIMG.sprite = trueSprite; 
            }
            else
            {
                ChecklistIMG.sprite = falseSprite;
            }

            toDoText.text = text;
        }
    }
}
