using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Image _fadeUI;
    [SerializeField] private float fadeInSpeed = 2f;
    [SerializeField] private float fadeOutSpeed = 2f;

    System.Action _callback;
    float alpha;
    Color defaultColor;
    Color alphaZero;

    void Awake()
    {
        defaultColor = _fadeUI.color;
        alphaZero = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, 0);
    }

    /// <summary>
    /// 明るくする
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIN()
    {
        // 念のため初期化
        _fadeUI.color = defaultColor;
        alpha = _fadeUI.color.a;
        while (0 < _fadeUI.color.a)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha -= Time.deltaTime / fadeInSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ループを抜けたらcallback
        if (_callback != null) _callback();
    }

    /// <summary>
    /// 暗くする
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOUT()
    {
        // 念のため初期化
        _fadeUI.color = alphaZero;
        alpha = _fadeUI.color.a;
        while (_fadeUI.color.a < 1)
        {
            _fadeUI.color = new Color(_fadeUI.color.r, _fadeUI.color.g, _fadeUI.color.b, alpha);
            alpha += Time.deltaTime / fadeOutSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // ループを抜けたらcallback
        if (_callback != null) _callback();
    }

    /// <summary>
    /// フェードイン・アウト
    /// </summary>
    /// <param name="fade">out か in を入れる</param>
    /// <param name="callback">フェード後の処理を入れる</param>
    public void Fade(string fade, System.Action callback = null)
    {
        _callback = callback;
        if (fade == "out")    { StartCoroutine(FadeOUT()); }
        else if(fade == "in") { StartCoroutine(FadeIN());  }
    }
}
