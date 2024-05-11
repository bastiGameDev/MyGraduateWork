using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdawn : MonoBehaviour
{
    public Dropdown resolutionDropdown; // ссылка на список с разрешениями на канвасе

    private Resolution[] resolutions; // массив доступных разрешений

    private void Awake()
    {
        // получаем массив доступных разрешений
        resolutions = Screen.resolutions;

        // заполняем список на канвасе доступными разрешениями
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // подписываемся на событие изменения значения списка
        resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownValueChanged);
    }

    private void OnResolutionDropdownValueChanged(int index)
    {
        // устанавливаем новое разрешение экрана
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void OnDestroy()
    {
        // отписываемся от события изменения значения списка
        resolutionDropdown.onValueChanged.RemoveListener(OnResolutionDropdownValueChanged);
    }
}