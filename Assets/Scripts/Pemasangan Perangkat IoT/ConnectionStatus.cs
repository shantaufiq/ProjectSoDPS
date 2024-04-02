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
        [SerializeField] private Sprite warningSprite;
        [SerializeField] private GameObject valueWarning;
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
                    valueWarning.gameObject.SetActive(false);
                    break; 
                case Status.Error:
                    valueStatus.text = error;
                    panelImage.sprite = errorSprite;
                    valueWarning.gameObject.SetActive(false);
                    break;
                case Status.Warning:
                    valueStatus.text = connected;
                    panelImage.sprite = warningSprite;
                    valueWarning.gameObject.SetActive(true);
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
