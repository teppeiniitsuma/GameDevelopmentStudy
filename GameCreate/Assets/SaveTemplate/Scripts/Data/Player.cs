using UnityEngine;

[System.Serializable]
public class Player
{
    //public string name = "name";

    public int level = 1;
    public int hp = 100;
    public int max_hp = 100;
    public int mp = 10;
    public int max_mp = 10;
    public int att = 10;

    public Vector3 pos = new Vector3(0, 0, 0);
}
