using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public int hp = 10;
    public int mp = 10;
    public int att = 10;

    public Vector3 pos = new Vector3(0, 0, 0);
}
