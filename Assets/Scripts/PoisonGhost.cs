using UnityEngine;

public class PoisonGhost : MonoBehaviour
{
    // Projectile prefab to be instantiated when shooting
    public GameObject projectilePrefab;
    // Point from which the projectile will be fired
    public Transform shootPoint;
    //  Time interval between shots in seconds
    public float fireInterval = 2f;
// Reference to the player for aiming
    private Transform player;
    // Timer to track time since last shot
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObject != null)        {
            player = PlayerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null && enemyMovement.isStunned) return; // Skip shooting when stunned
        

    transform.LookAt(player); // Face the player
    timer += Time.deltaTime;
    if (timer >= fireInterval)
    {
        Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        timer = 0f;
        
    }
}
}
