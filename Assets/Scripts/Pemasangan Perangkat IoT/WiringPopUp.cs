using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seville;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using Tproject.AudioManager;

namespace InstalasiIoT
{
    public class WiringPopUp : PopUpController
    {
        [SerializeField] private TextMeshProUGUI headerTMP;
        [SerializeField] private string headerText;
        [SerializeField] private SfxHandler sfxHandler;
        private bool showFirstTime = false;
        private bool grabbedFirstTime = false;

        public void Enabled(bool value)
        {
            this.enabled = value;
        }

        public void OpenPopup()
        {
            if (!grabbedFirstTime)
            {
                sfxHandler.PlaySfxClip("Info Tugas");
                grabbedFirstTime = true;
            }

            if (showFirstTime) return;
            headerTMP.text = headerText;
            OnClickOpenPopup();
            showFirstTime = true;
        }

        public void ClosePopup()
        {
            OnClickClosePopup();
            showFirstTime = false;
        }

        public void ChangeScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
