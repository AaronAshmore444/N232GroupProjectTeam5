
using UnityEngine;

public class PoisonProjectile : MonoBehaviour
{
    // Speed of the projectile in units per second
    public float speed = 10f;
    // Time in seconds before the projectile is destroyed
    public float aliveTime = 3f;
    // Poison damage parameters
    public int poisonDamagePerSecond = 2;
    // Duration of the poison effect in seconds
    public float poisonDuration = 3f;
// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }
// Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = transform.forward;
        float distance = speed * Time.deltaTime;
        if (Physics.Raycast(currentPosition, direction, out RaycastHit hit, distance)) // Check for collisions with enemies or the player
        {
           HandleHit(hit.collider);
           return;
        }
        transform.position += direction * distance;
    }
// Method to handle collisions with enemies or the player
     void HandleHit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            return;
        }
       

        if (other.CompareTag("Player"))
        {

        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ApplyPoison(poisonDamagePerSecond, poisonDuration);
            Debug.Log("Poison applied. Current health: " + playerHealth.currentHealth);
        }
       
        }
        Destroy(gameObject);
    }
}
