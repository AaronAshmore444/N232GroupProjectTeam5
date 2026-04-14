using UnityEngine;

public class LockTarget : MonoBehaviour
{
    public DoorOpen door;
    
    public GameObject linkedLock;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
     {
        
        if (linkedLock != null)
        {
            Destroy(linkedLock);
        }

        if (door != null)
        {
            door.OnLockDestoy();
        }
    }
}