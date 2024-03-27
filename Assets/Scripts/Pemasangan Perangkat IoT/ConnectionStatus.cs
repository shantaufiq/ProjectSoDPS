using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InstalasiIoT
{
    public class ConnectionStatus : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueStatus;
        [SerializeField] private string connected;
        [SerializeField] private Sprite connectedSprite;
        [SerializeField] private string error;
        [SerializeField] private Sprite errorSprite;
        [SerializeField] private Image panelImage;


        public void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Connected:
                    valueStatus.text = connected;
                    panelImage.sprite = connectedSprite;
                    break; 
                case Status.Error:
                    valueStatus.text = error;
                    panelImage.sprite = errorSprite;
                    break;
                case Status.Warning:
                    // TODO: Add warning status
                    Debug.Log("Kabel warna tidak sesuai");
                    break;
            }
        }
    }

    public enum Status
    {
        Warning,
        Connected,
        Error
    }
}
