using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public GameObject lock1;
    public GameObject lock2;

    
    private int destroyedLock = 0;
    private int totalLocks = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (lock1 != null) totalLocks++;
        if (lock2 != null) totalLocks++;
    }

    public void OnLockDestoy()
    {
        destroyedLock++;

        if (destroyedLock >= totalLocks)
        {
            Destroy(gameObject);
        }
    }
}