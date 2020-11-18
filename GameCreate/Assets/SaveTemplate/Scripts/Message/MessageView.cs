using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{

    // メッセージ表示関係

    Text _messageText;

    void Start()
    {
        _messageText = GetComponent<Text>();
    }

    public void SetMessage(string message)
    {
        _messageText.text = message;
    }

    public void ClearMessage()
    {
        _messageText.text = "";
    }
}
