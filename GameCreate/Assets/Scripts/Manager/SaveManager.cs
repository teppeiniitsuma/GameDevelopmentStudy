using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    private string folderName;
    private string fileName;
    private readonly string folderPath = @"Resources\Save\SaveData";
    private readonly string filePath   = @"Resources\Save\SaveData\saveData";
    public static int num = 1;

    /// <summary>
    /// 初期化
    /// </summary>
    void Initialize()
    {
        folderName = Path.Combine(Application.dataPath, folderPath);
        fileName   = Path.Combine(Application.dataPath, filePath);
    }

    public void Delete()
    {
        Initialize();
        if (Directory.Exists(folderName) == true)
        {
            //　UnityEditor上だと子要素だけ削除
            try
            {
                Directory.Delete(folderName, recursive: true);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            Debug.Log(folderName + "を削除しました。");
        }
        else
        {
            Debug.Log(folderName + "は存在しません。");
        }
    }
    /// <summary>
    /// SaveFolderがない場合作成
    /// </summary>
    public void CreateData()
    {
        Initialize();
        FileStream fs = null;

        if(Directory.Exists(folderName) == false)
        {
            try
            {
                Directory.CreateDirectory(folderName);
                //　Disposeしないとファイルの削除時に不具合が出る
                using (fs = File.Create(folderName))
                {
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            Debug.Log(folderName + "にフォルダを作成しました。");

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
        writer = new StreamWriter(fileName + n + ".json", false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public Player LoadPlayerData(int n)
    {
        Initialize();
        string data = "";
        StreamReader reader;

        if (File.Exists(fileName + n + ".json") == true)
        {
            reader = new StreamReader(fileName + n + ".json");
            data = reader.ReadToEnd();
            reader.Close();
        }
        return JsonUtility.FromJson<Player>(data);
    }
}
