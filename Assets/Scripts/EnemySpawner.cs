using UnityEngine;

public class Spawner : MonoBehaviour
{
public GameObject spawnPrefab;
public float spawnInterval = 2f;
private float timer = 5f;
private int enemiesSpawned = 0;
public int maxEnemies = 5;
public float spawnRadius = 5f;
void Update()
{
Vector3 offset = new Vector3(
    Random.Range(-spawnRadius, spawnRadius),
    0,
    Random.Range(-spawnRadius, spawnRadius)
);
if (enemiesSpawned >= maxEnemies)
    return;
timer += Time.deltaTime;
if (timer >= spawnInterval)
{
GameObject newObject= Instantiate(
spawnPrefab,
transform.position + offset,
Quaternion.identity
);
timer = 0f;
enemiesSpawned++;
}
}

}
