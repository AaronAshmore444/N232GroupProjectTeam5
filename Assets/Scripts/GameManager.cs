using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Variable for trap text
    public TMP_Text trapText;
    //Variable to track number of traps held
    public int trapNum;
    // Tracks player points
    public int ghostPoints = 0;

    void Start()
    {
        //set trap number to 1 and updates trap text
        trapNum = 1;
        trapText.text = "Traps: (" + trapNum + "/1)";
    }

    // Method to add points when an enemy is killed
    public void AddPoints(int points)
    {
        ghostPoints += points;
        Debug.Log("Points: " + ghostPoints);
    }

    //Adds a trap to your inventory
    public void AddTrap(int traps)
    {
        trapNum += traps;
        trapText.text = "Traps: (" + trapNum + "/1)";
    }

    //Removes a trap from your inventory
    public void LoseTrap(int traps)
    {
        trapNum -= traps;
        trapText.text = "Traps: (" + trapNum + "/1)";
    }


}
