using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float horizontalSpeed = 2.0f;

    private float horizontal = 0.0f;

    void Update()
    {
        horizontal += Input.GetAxis("Mouse X") * horizontalSpeed;

        transform.position = target.position + Quaternion.Euler(0, horizontal, 0) * offset;
        transform.LookAt(target.position);
    }
}