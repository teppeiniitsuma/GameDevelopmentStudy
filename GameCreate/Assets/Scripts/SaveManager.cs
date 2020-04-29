using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    private string folderPath;
    private string filePath;

    public void Save(int n)
    {

    }
    public void Load()
    {

    }

    public void DeleteData()
    {

    }
    /// <summary>
    /// SaveFolderがない場合作成
    /// </summary>
    public void CreateData()
    {
        FileStream fs = null;
        folderPath = Path.Combine(Application.dataPath, @"Save\SaveData");

        if(Directory.Exists(folderPath) == false)
        {
            try
            {
                Directory.CreateDirectory(folderPath);
                //　Disposeしないとファイルの削除時に不具合が出る
                using (fs = File.Create(folderPath))
                {
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            Debug.Log(folderPath + "にフォルダを作成しました。");

        }
        else
        {
            Debug.Log("Folderはすでに存在しています");
            return;
        }
    }
    public void savePlayerData(int n, Player p)
    {
        StreamWriter writer;

        string json = JsonUtility.ToJson(p);
        string dataPath = Path.Combine(Application.dataPath, @"Save\File\saveData");
        writer = new StreamWriter(dataPath + n + ".json", false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public Player loadPlayerData(int n)
    {
        string data = "";
        StreamReader reader;
        string dataPath = Path.Combine(Application.dataPath, @"Save\File\saveData");

        if (File.Exists(dataPath) == false)
        {
            try
            {

            }
            catch
            {

            }
        }
        else
        {
            reader = new StreamReader(dataPath + n + ".json");
            data = reader.ReadToEnd();
            reader.Close();
        }

        return JsonUtility.FromJson<Player>(data);
    }
}
