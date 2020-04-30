using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerController pl;
    Player player;
    [SerializeField] Text hpText;

    void Start()
    {
        pl = FindObjectOfType<PlayerController>();
        player = pl.GetPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP : " + player.hp + " / " + player.max_hp;
    }
}
