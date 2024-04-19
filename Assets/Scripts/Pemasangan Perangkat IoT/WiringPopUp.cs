using Seville;
using TMPro;
using Tproject.AudioManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InstalasiIoT
{
    public class WiringPopUp : PopUpController
    {
        [SerializeField] private TextMeshProUGUI headerTMP;
        [SerializeField] private string headerText;
        [SerializeField] private SfxHandler sfxHandler;
        private bool showFirstTime = false;

        public void Enabled(bool value)
        {
            this.enabled = value;
        }

        public void OpenPopup()
        {
            if (showFirstTime) return;
            sfxHandler.PlaySfxClip("Info Tugas");
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
