using UnityEngine;

public class Spawner : MonoBehaviour
{
public GameObject spawnPrefab;
public float spawnInterval = 2f;
private float timer = 5f;
private int enemiesSpawned = 0;
public int maxEnemies = 5;
void Update()
{
if (enemiesSpawned >= maxEnemies)
    return;
timer += Time.deltaTime;
if (timer >= spawnInterval)
{
GameObject newObject= Instantiate(
spawnPrefab,
transform.position,
Quaternion.identity
);
timer = 0f;
enemiesSpawned++;
}
}
}
