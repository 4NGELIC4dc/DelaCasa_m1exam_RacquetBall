using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float bounceForce = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Racquet"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 forceDirection = transform.position - other.transform.position;
            rb.AddForce(forceDirection.normalized * 10f, ForceMode.Impulse);
        }
    }
}
