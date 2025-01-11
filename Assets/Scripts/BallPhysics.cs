using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float bounceForce = 10f;
    private GameObject player;
    private ScoreManager scoreManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found.");
        }
        else
        {
            Debug.Log("ScoreManager successfully found.");
        }

        if (player != null)
        {
            Collider ballCollider = GetComponent<Collider>();
            Collider playerCollider = player.GetComponent<Collider>();

            if (ballCollider != null && playerCollider != null)
            {
                Physics.IgnoreCollision(ballCollider, playerCollider);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Court"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, bounceForce, rb.velocity.z);
            Debug.Log("Ball bounced off " + collision.gameObject.name);
        }
    }
}
