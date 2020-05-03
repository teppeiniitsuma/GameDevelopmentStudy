using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    SaveManager save = new SaveManager();
    PlayerController p;
    public int num;

    public void Push()
    {
        LoadScene();
    }
    public void DataSave()
    {
        Player player = p.GetPlayer;
        save.savePlayerData(SaveManager.num, player);
        Debug.Log(save);
    }

    public void LoadScene()
    {
        StartCoroutine(LoadTime());
        //SaveManager.num = this.num;
        //SceneManager.LoadScene("Main");
    }

    public IEnumerator LoadTime()
    {
        SaveManager.num = this.num;
        var async = SceneManager.LoadSceneAsync("Main");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        async.allowSceneActivation = true;
    }

    public void DeleteData()
    {
        save.Delete();
    }
    // Start is called before the first frame update
    void Awake()
    {
        p = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
