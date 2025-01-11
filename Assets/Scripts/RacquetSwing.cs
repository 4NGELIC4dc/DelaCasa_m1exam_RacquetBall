using UnityEngine;

public class RacquetSwing : MonoBehaviour
{
    public float swingSpeed = 500f; // Speed of swing
    public float returnSpeed = 300f; // Speed to return to default position
    private bool isSwinging = false;
    private float targetRotation = -90f; // Adjust as needed (negative for a more natural swing)
    private float defaultRotationY; // Store default Y rotation

    void Start()
    {
        defaultRotationY = transform.localEulerAngles.y; // Save the default rotation
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to swing
        {
            isSwinging = true;
        }

        if (isSwinging)
        {
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation, Quaternion.Euler(0, defaultRotationY + targetRotation, 0), swingSpeed * Time.deltaTime
            );

            if (Mathf.Approximately(transform.localEulerAngles.y, defaultRotationY + targetRotation))
            {
                isSwinging = false;
            }
        }
        else
        {
            // Return to default horizontal position
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation, Quaternion.Euler(0, defaultRotationY, 0), returnSpeed * Time.deltaTime
            );
        }
    }
}
