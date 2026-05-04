using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Volume objects
    public Slider VolumeSlider;
    public TMP_Text VolumeAmount;

    // Display objects
    public TMP_Dropdown DisplayDropdown;

    // Mouse Sensitivity objects
    public Slider SensitivitySlider;
    public TMP_Text SensitivityAmount;

    private void Start()
    {
        VolumeSlider.value = GameSettings.Instance.Volume;
        VolumeAmount.text = GameSettings.Instance.Volume.ToString();

        DisplayDropdown.value = GameSettings.Instance.Display;

        SensitivitySlider.value = GameSettings.Instance.PlayerMouseSensitivity / 100f;
        SensitivityAmount.text = (GameSettings.Instance.PlayerMouseSensitivity / 100f).ToString();
    }

    public void OnVolumeSilderChange()
    {
        Debug.Log("Volume changed: " + (int) VolumeSlider.value);
        AudioListener.volume = ((int) (VolumeSlider.value)) / 100f;
        VolumeAmount.text = ((int)(VolumeSlider.value)).ToString();
        GameSettings.Instance.Volume = (int)(VolumeSlider.value);
    }

    public void OnDisplayModeChanged()
    {
        switch (DisplayDropdown.value) {
            case 0: Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen; break;
            case 1: Screen.fullScreenMode = FullScreenMode.FullScreenWindow; break;
            case 2: Screen.fullScreenMode = FullScreenMode.MaximizedWindow; break;
            case 3: Screen.fullScreenMode = FullScreenMode.Windowed; break;
            default: Debug.Log("Unknown display mode type!"); break;
        }

        GameSettings.Instance.Display = DisplayDropdown.value;
    }

    public void OnMouseSensitivitySliderChange()
    {
        Debug.Log("Mouse Sensitivity changed: " + SensitivitySlider.value);
        GameSettings.Instance.PlayerMouseSensitivity = SensitivitySlider.value * 100f;
        SensitivityAmount.text = SensitivitySlider.value.ToString();
    }

    public void OnBackButtonPress()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
