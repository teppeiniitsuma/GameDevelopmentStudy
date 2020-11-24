using UnityEngine;

public class VisitorPlayerMover : MonoBehaviour, IVisitor
{
    public void Visitor(IAcceptor acceptor)
    {
        acceptor.Acceptor(this);
        Debug.Log("test");
    }

    private void OnCollisionEnter(Collision collision)
    {
        var acc = collision.gameObject.GetComponent<IAcceptor>();
        if(null != acc) { Visitor(acc); }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += (Vector3.right / 10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position -= (Vector3.right / 10);
        }
    }
}
