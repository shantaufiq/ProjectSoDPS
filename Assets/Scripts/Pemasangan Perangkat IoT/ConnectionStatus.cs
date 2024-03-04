using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InstalasiIoT
{
    public class ConnectionStatus : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueStatus;
        [SerializeField] private string connected;
        [SerializeField] private string disconnected;
        [SerializeField] private string error;
        [SerializeField] private Image panelImage;


        public void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Connected:
                    valueStatus.text = connected;
                    panelImage.color = Color.green;
                    break;
                case Status.Error:
                    valueStatus.text = error;
                    panelImage.color = Color.red;
                    break;
            }
        }
    }

    public enum Status
    {
        Connected,
        Error
    }
}
