using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class FileSave : MonoBehaviour
{
    public Text text;
    private string folderPath;
    private string subFolderPath;
    private string filePath;

    // Use this for initialization
    void Start()
    {
        folderPath = Path.Combine(Application.dataPath, @"Save\File");
        filePath = Path.Combine(folderPath, "test.txt");

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            text.text = "";
            if (Directory.Exists(folderPath))
            {
                //　UnityEditor上だと子要素だけ削除
                try
                {
                    Directory.Delete(folderPath, recursive: true);
                }
                catch (Exception e)
                {
                    text.text = e.Message;
                }
                text.text = folderPath + "を削除しました。";
            }
            else
            {
                text.text = folderPath + "は存在しません。";
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            text.text = "";
            text.text = "フォルダパス : " + folderPath;
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            text.text = "";

            FileStream fs = null;

            try
            {
                Directory.CreateDirectory(filePath);
                //　Disposeしないとファイルの削除時に不具合が出る
                using (fs = File.Create(filePath))
                {
                }
            }
            catch (Exception e)
            {
                text.text = e.Message;
            }

            text.text = filePath + "にフォルダ、ファイルを作成しました。";
        }
    }
}
