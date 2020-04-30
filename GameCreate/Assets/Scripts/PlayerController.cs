using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player = new Player();
    SaveManager save = new SaveManager();

    public Player GetPlayer { get { return player; } }

    void Moves()
    {
        this.transform.position = player.pos;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.pos.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.pos.x -= 1;
        }

        if (Input.GetMouseButtonDown(1))
        {
            player.hp--;
        }
    }
    void Awake()
    {
        if(save.loadPlayerData(SaveManager.num) != null)
            player = save.loadPlayerData(SaveManager.num);
        Debug.Log(player.pos);
    }

    // Update is called once per frame
    void Update()
    {
        Moves();
    }
}
