using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 50f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 zoomDirection = transform.forward * scroll * zoomSpeed;
            Vector3 newPosition = transform.position + zoomDirection;

            float distance = Vector3.Distance(newPosition, Vector3.zero);
            if (distance > minZoom && distance < maxZoom)
            {
                transform.position = newPosition;
            }
        }
    }
}
