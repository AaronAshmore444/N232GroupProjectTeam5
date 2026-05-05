using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Variable for trap text
    public TMP_Text trapText;
    public TMP_Text pointText;
    //Variable to track number of traps held
    public int trapNum;
    // Tracks player points
    public int ghostPoints = 0;

    public TMP_Text BulletsText;
    public GunManager GunManager;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winningPanel;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject gotoMainMenuButton;
    

    void Start()
    {
        //set trap number to 1 and updates trap text
        trapNum = 1;
        trapText.text = "Traps: (" + trapNum + "/1)";
        ghostPoints = 0;
        pointText.text = "Points: " + ghostPoints;

        UpdateBulletsText();
    }

    public void UpdateBulletsText()
    {
        BulletsText.text = "Bullets: " + GunManager.TotalBullets.ToString();

    }

    // Method to add points when an enemy is killed
    public void AddPoints(int points)
    {
        Debug.Log("Add Points called with: " + points);
        ghostPoints += points;
        Debug.Log("Points: " + ghostPoints);
        pointText.text = "Points: " + ghostPoints;
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

    public void Update()
    {

        if (playerHealth.currentHealth <= 0)
        {
            if (gameOverPanel != null) gameOverPanel.SetActive(true);
            if (gotoMainMenuButton != null) gotoMainMenuButton.SetActive(true);
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            if (ghostPoints >= 300)
        {
            if (winningPanel != null) winningPanel.SetActive(true);
            if (gotoMainMenuButton != null) gotoMainMenuButton.SetActive(true);
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        }
        
    }

    public void GoToMainMenu()
    {
        if (winningPanel != null) winningPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (gotoMainMenuButton != null) gotoMainMenuButton.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("HomeScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
