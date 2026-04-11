using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Tracks player points
    public int ghostPoints = 0;

    // Method to add points when an enemy is killed
    public void AddPoints(int points)
    {
        ghostPoints += points;
        Debug.Log("Points: " + ghostPoints);
    }
}
