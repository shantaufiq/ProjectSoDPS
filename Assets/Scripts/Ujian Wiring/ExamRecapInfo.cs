using InstalasiIoT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class ExamRecapInfo : ConnectionStatus
    {
        [SerializeField] private ExamScoreChecker examScoreChecker;

        public override void SetStatus(Status status)
        {
            if (examScoreChecker.examSubmitted) return;
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
