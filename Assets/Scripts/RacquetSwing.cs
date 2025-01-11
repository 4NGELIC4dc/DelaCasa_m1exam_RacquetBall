using UnityEngine;

public class RacquetSwing : MonoBehaviour
{
    public float swingSpeed = 500f;
    public float returnSpeed = 300f;
    public Transform hitbox;  
    public float hitForce = 20f;

    private bool isSwinging = false;
    private float targetRotation = -90f;
    private float defaultRotationY;
    private ScoreManager scoreManager;

    void Start()
    {
        defaultRotationY = transform.localEulerAngles.y;
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
            transform.localRotation = Quaternion.RotateTowards(
                transform.localRotation, Quaternion.Euler(0, defaultRotationY, 0), returnSpeed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isSwinging && other.CompareTag("Ball"))
        {
            Debug.Log("Ball hit detected inside hitbox.");

            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                Vector3 hitDirection = (Vector3.up * 1.5f + transform.forward).normalized;
                ballRb.velocity = hitDirection * hitForce;

                if (scoreManager != null)
                {
                    scoreManager.IncreaseHitCount();
                    Debug.Log("Score Updated: " + scoreManager);
                }
            }
        }
    }
}
