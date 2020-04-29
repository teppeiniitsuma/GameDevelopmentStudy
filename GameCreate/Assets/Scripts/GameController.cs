using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    SaveManager save;
    void Awake()
    {
        save = new SaveManager();
        save.CreateData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
