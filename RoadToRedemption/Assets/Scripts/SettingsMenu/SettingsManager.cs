using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SettingsManager : MonoBehaviour
{
    public Toggle postProcessingToggle; 
    public PostProcessVolume postProcessVolume; 
    public Slider volumeSlider;

    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject pauseMenu;
    private void Awake()
    {
        postProcessingToggle.isOn = postProcessVolume.enabled;
        
        postProcessingToggle.onValueChanged.AddListener(OnPostProcessingToggleChanged);
        
        volumeSlider.value = AudioListener.volume;

        volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelSettings.SetActive(false);
        }
    }
    private void OnVolumeSliderValueChanged(float value)
    {
        AudioListener.volume = value;

        PlayerPrefs.SetFloat("SelectedVolume", value);
    }

    private void OnPostProcessingToggleChanged(bool isOn)
    {
        postProcessVolume.enabled = isOn;
    }

    public void HideSettings()
    {
        panelSettings.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        pauseMenu.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void HideSettingsMainMenu()
    {
        panelSettings.SetActive(false);
    }

    private void OnDestroy()
    {
        postProcessingToggle.onValueChanged.RemoveListener(OnPostProcessingToggleChanged);
        volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderValueChanged);
    }
}