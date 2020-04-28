using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{

    public void savePlayerData(int n, Player p)
    {
        StreamWriter writer;

        string json = JsonUtility.ToJson(p);
        string dataPath = Application.dataPath;
        writer = new StreamWriter(dataPath + "/Save/savedata" + n + ".json", false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public Player loadPlayerData(int n)
    {
        string data = "";
        StreamReader reader;
        string dataPath = Application.dataPath;
        reader = new StreamReader(dataPath + "/Save/savedata" + n + ".json");
        data = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Player>(data);
    }
}
