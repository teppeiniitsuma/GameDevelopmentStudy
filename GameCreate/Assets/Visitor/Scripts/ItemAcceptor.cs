using UnityEngine;

public class ItemAcceptor : MonoBehaviour,IAcceptor
{

    public void Acceptor(IVisitor visitor)
    {
        Debug.Log("item get");
        ItemCounter.Instance.Items.redItem++;
        Debug.Log(ItemCounter.Instance.Items.redItem);
        this.gameObject.SetActive(false);
    }
}
