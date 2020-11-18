using UnityEngine;

public class ItemAcceptor : MonoBehaviour,IAcceptor
{

    public void Acceptor(IVisitor visitor)
    {
        Debug.Log("item get");
        this.gameObject.SetActive(false);
    }


}
