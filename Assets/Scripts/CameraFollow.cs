using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ObjectToFollow;

    void Update()
    {
        transform.position = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y, -10);
    }
}
