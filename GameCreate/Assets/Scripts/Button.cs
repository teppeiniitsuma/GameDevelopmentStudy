using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    SaveManager save = new SaveManager();
    SceneController scene;
    PlayerController p;
    public int num;



    public void Push()
    {
        LoadScene();
    }
    public void DataSave()
    {
        Player player = p.GetPlayer;
        save.SavePlayerData(SaveManager.num, player);
        Debug.Log(save);
    }

    public void LoadScene()
    {
        SaveManager.num = this.num;
        StartCoroutine(scene.Load());
    }

   

    public void DeleteData()
    {
        save.Delete();
    }
    // Start is called before the first frame update
    void Awake()
    {
        p = FindObjectOfType<PlayerController>();
        scene = FindObjectOfType<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
