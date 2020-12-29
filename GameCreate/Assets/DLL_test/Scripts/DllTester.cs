using UnityEngine;
using System.Runtime.InteropServices;

static class DLL
{
    [DllImport("DLLtest", CallingConvention = CallingConvention.StdCall)]
    public static extern int Add_function(int a, int b);
}
public class DllTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DLL.Add_function(3, 4));
    }

}
