using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    SaveManager save = new SaveManager();
    PlayerController p;
    public int num;

    public void Push()
    {
        Player player = p.GetPlayer;
        save.savePlayerData(num, player);
        Debug.Log(save);
    }
    // Start is called before the first frame update
    void Awake()
    {
        p = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
