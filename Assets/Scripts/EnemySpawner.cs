using UnityEngine;

public class Spawner : MonoBehaviour
{
public GameObject GhostPrefab;
// Time interval between spawns
public float spawnInterval = 2f;
// Timer to track time since last spawn
private float timer = 0f;
// Counter to track the number of enemies spawned
private int enemiesSpawned = 0;
// Maximum number of enemies to spawn
public int maxEnemies = 5;
// Radius around the spawner where enemies will be spawned
public float spawnRadius = 5f;


// Update is called once per frame
void Update()
{
    if (enemiesSpawned >= maxEnemies) // Check if we've reached the maximum number of enemies
        return;
timer += Time.deltaTime;
// Spawn a ghost at a random position around the spawner every spawnInterval seconds
if (timer >= spawnInterval)
{ 
    Vector3 offset = new Vector3( 
    Random.Range(-spawnRadius, spawnRadius),
    0,
    Random.Range(-spawnRadius, spawnRadius)
);
// Instantiate the ghost at a random position around the spawner
    Instantiate(GhostPrefab, transform.position + offset, Quaternion.identity); 
    enemiesSpawned++;
}
}

}



