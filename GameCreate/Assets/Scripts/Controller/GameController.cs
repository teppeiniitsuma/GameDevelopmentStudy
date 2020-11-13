using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameController : MonoBehaviour
{
    SaveManager save;
    void Awake()
    {
        save = new SaveManager();
        Debug.Log(SaveManager.num);
        save.CreateData();
    }

}
