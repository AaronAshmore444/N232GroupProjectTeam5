using UnityEngine;
using TMPro;

public class ThrownGadget : MonoBehaviour
{
    //Varible to check if player is near the trap
    private bool playerInRange = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        


        //If player is near trap, set trap to be picked up
        if (other.CompareTag("Player"))
        {
            
            playerInRange = true;
            other.GetComponent<PlayerController>().currentGadget = gameObject;


        }

    }
    //If player is not near trap, remove trap to be picked up
    private void OnTriggerExit(Collider other) {

         
        if (other.CompareTag("Player"))
        {
            
            playerInRange = false;
            other.GetComponent<PlayerController>().currentGadget = null;


        }

    }
}
