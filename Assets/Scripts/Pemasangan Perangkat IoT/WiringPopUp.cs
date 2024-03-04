using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seville;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace InstalasiIoT
{
    public class WiringPopUp : PopUpController
    {
        [SerializeField] private TextMeshProUGUI headerTMP;
        [SerializeField] private string headerText;


        public void OpenPopup()
        {
            headerTMP.text = headerText;
            OnClickOpenPopup();
        }

        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
