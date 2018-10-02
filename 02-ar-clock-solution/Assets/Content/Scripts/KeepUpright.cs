using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    void Update()
    {
        var euler = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(0, euler.y, 0));
    }
}