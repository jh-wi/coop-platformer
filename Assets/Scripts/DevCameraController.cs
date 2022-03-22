using UnityEngine;
public class DevCameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = target.position+offset;
    }
}
