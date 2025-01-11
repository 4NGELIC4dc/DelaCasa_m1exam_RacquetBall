using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; 
    public Transform spawnPoint; 

    public void SpawnBall()
    {
        Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            SpawnBall();
        }
    }
}
