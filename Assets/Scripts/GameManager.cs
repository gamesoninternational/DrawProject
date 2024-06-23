using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPrefab; // Changed from int to GameObject
    public Transform SpawnLocation; // Changed to Transform for easier position access
    public float MinSpeed, MaxSpeed;
    public float MinSpawnRate, MaxSpawnRate;

    public float SpeedAttack = 1f;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Instantiate the enemy at the spawn location
            GameObject enemy = Instantiate(EnemyPrefab, SpawnLocation.position, SpawnLocation.rotation);

            // Randomize the move speed between 5 and 10
            float moveSpeed = Random.Range(MinSpeed, MaxSpeed);

            // Start the enemy movement coroutine with the randomized move speed
            StartCoroutine(MoveTowardsPlayer(enemy, moveSpeed));

            // Randomize the spawn rate between 3 and 5 seconds
            float spawnRate = Random.Range(MinSpawnRate, MaxSpawnRate);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator MoveTowardsPlayer(GameObject enemy, float moveSpeed)
    {
        while (enemy != null && Player != null)
        {
            // Calculate the step size based on the random move speed
            float step = moveSpeed * Time.deltaTime;

            // Move the enemy towards the player
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, Player.transform.position, step);

            // Wait until the next frame
            yield return null;
        }
    }
}
