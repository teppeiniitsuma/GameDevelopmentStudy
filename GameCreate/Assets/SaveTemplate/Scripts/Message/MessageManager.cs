using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private List<MessagePresenter> _messagePresentersLists = new List<MessagePresenter>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _messagePresentersLists[(int)CommonParam.TextType.MainText].
                SetMessage(CommonParam.TextType.MainText, "お試しメッセージ", () => Debug.Log("メッセージ終了"));
        }
    }
}
