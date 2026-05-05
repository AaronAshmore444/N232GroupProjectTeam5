using UnityEngine;

public class TrapPickup : MonoBehaviour
{

    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public GameManager GameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.trapNum == 0)
        {
            GameManager.AddTrap(1);
            playerController.SetGadget(true);
            bool check = playerController.GetGadget();
            Destroy(gameObject);
            
        }
    }
    }
