using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public void OnPlayClick()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Play Screen");
    }

    public void OnOptionsClick()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Options Screen");
    }
}
