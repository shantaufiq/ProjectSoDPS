using InstalasiIoT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class ExamRecapInfo : ConnectionStatus
    {

        public override void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Connected:
                    PanelImage.sprite = ConnectedSprite;
                    break;
                case Status.Error:
                    PanelImage.sprite = ErrorSprite;
                    break;
                case Status.Warning:
                    PanelImage.sprite = WarningSprite;
                    break;
            }
        }
    }
}
