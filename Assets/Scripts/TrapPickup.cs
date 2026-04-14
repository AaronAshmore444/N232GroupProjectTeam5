using UnityEngine;

public class TrapPickup : MonoBehaviour
{

    public GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.trapNum == 0)
        {
            gameManager.AddTrap(1);
        }
    }
    }
