using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    
    
   
    public float damageAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.tag == "Player" || other.tag == "Gun") return;

        // Apply damage if the object has HealthPoints
        
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null) enemy.TakeDamage(damageAmount);
        

        
    }
}
