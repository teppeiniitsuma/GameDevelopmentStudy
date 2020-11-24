using UnityEngine;
using UnityEngine.UI;

public class EnemyDataSet : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private Text _text;

    void Start()
    {
        _text.text =
                    "名前：　" + data.enemyName + "\n"
                  + "体力：　" + data.maxHp + "\n"
                  + "攻撃：　" + data.atk + "\n"
                  + "防御：　" + data.def + "\n"
                  + "経験：　" + data.def + "\n".ToString();
    }

}
