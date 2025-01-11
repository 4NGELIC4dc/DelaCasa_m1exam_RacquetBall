using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // Assign Ball prefab in Inspector
    public Transform spawnPoint; // Assign BallSpawnPoint in Inspector

    public void SpawnBall()
    {
        Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // Press B to spawn ball
        {
            SpawnBall();
        }
    }
}
