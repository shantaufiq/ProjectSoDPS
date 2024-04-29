using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class PasskeyValidation : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text_returnMessage;
    [SerializeField] private string passkey;
    public UnityEvent OnPasskeyTrue;

    void Start()
    {
        if (text_returnMessage)
            text_returnMessage.text = $" ";
    }

    public void ValidatingPassKey()
    {
        if (!string.IsNullOrEmpty(inputField.text) && inputField.text == passkey)
        {
            OnPasskeyTrue.Invoke();
            if (text_returnMessage)
                text_returnMessage.text = $"Correct passkey";
        }
        else
        {
            if (text_returnMessage)
                text_returnMessage.text = $"Incorrect passkey";
        }
    }
}
