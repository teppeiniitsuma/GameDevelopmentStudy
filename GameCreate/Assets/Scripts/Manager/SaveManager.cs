using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    private string folderPath;
    private string filePath;
    public static int num = 1;

    /// <summary>
    /// 初期化
    /// </summary>
    void Initialize()
    {
        folderPath = Path.Combine(Application.dataPath, @"Resources\Save\SaveData");
        filePath   = Path.Combine(Application.dataPath, @"Resources\Save\SaveData\saveData");
    }

    public void Delete()
    {
        Initialize();
        if (Directory.Exists(folderPath) == true)
        {
            //　UnityEditor上だと子要素だけ削除
            try
            {
                Directory.Delete(folderPath, recursive: true);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            Debug.Log(folderPath + "を削除しました。");
        }
        else
        {
            Debug.Log(folderPath + "は存在しません。");
        }
    }
    /// <summary>
    /// SaveFolderがない場合作成
    /// </summary>
    public void CreateData()
    {
        Initialize();
        FileStream fs = null;

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
    public void SavePlayerData(int n, Player p)
    {
        Initialize();
        StreamWriter writer;

        string json = JsonUtility.ToJson(p);
        writer = new StreamWriter(filePath + n + ".json", false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public Player LoadPlayerData(int n)
    {
        Initialize();
        string data = "";
        StreamReader reader;

        if (File.Exists(filePath + n + ".json") == true)
        {
            reader = new StreamReader(filePath + n + ".json");
            data = reader.ReadToEnd();
            reader.Close();
        }
        return JsonUtility.FromJson<Player>(data);
    }
}
