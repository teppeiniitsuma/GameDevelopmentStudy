using UnityEngine;

public class ItemCounter : MonoBehaviour
{
    static string objName = "ItemCounter";

    public static ItemCounter Instance {
        get
        {
            if (_instance == null)
            {
                GameObject manager = new GameObject(objName);
                _instance = manager.AddComponent<ItemCounter>();
            }
            return _instance;
        }
    }
    static ItemCounter _instance;

    public ItemData Items { get => data; set => data = value; }
    ItemData data = new ItemData();

    void Awake()
    {
        _instance = this;
    }
}
