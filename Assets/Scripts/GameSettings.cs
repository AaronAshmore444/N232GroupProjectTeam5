using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public int Volume = 100;
    public int Display = 0;
    public float PlayerMouseSensitivity = 240f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object alive
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates when reloading
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Homescreen");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Options Screen");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
