using UnityEngine;

public class ThrownGadget : MonoBehaviour
{

    private bool playerInRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {



        
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            other.GetComponent<PlayerController>().currentGadget = gameObject;


        }

    }

    private void OnTriggerExit(Collider other) {

         
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            other.GetComponent<PlayerController>().currentGadget = null;


        }

    }
}
