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
        private bool showFirstTime = false;

        public void Enabled(bool value)
        {
            this.enabled = value;
        }

        public void OpenPopup()
        {
            if (showFirstTime) return;
            headerTMP.text = headerText;
            OnClickOpenPopup();
            showFirstTime = true;
        }

        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
