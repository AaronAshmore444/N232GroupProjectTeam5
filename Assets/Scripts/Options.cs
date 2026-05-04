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

    public void OnVolumeSilderChange()
    {
        Debug.Log("Volume changed: " + (int) VolumeSlider.value);
        AudioListener.volume = (int) (VolumeSlider.value) / 1000;
        VolumeAmount.text = ((int)(VolumeSlider.value)).ToString();
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
    }

    public void OnMouseSensitivitySliderChange()
    {
        Debug.Log("Mouse Sensitivity changed: " + SensitivitySlider.value);
        GameManager.Instance.PlayerMouseSensitivity = SensitivitySlider.value * 100f;
        SensitivityAmount.text = SensitivitySlider.value.ToString();
    }

    public void OnBackButtonPress()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
