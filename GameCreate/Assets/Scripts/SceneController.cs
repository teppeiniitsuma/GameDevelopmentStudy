using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    AsyncOperation async;
    [SerializeField] private GameObject loadUI;
    [SerializeField] private Slider slider;

    public IEnumerator Load()
    {
        loadUI.SetActive(true);
        async = SceneManager.LoadSceneAsync("Main");
        async.allowSceneActivation = false;
        while (async.isDone == false)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
            if (slider.value == slider.maxValue)
            {
                yield return new WaitForSeconds(1);
                async.allowSceneActivation = true;

            }
        }
    }
    void Start()
    {
        loadUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
