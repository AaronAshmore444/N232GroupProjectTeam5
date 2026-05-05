using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public void OnPlayClick()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Level 1");
    }

    public void OnOptionsClick()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
