using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seville;
using TMPro;

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
    }
}
