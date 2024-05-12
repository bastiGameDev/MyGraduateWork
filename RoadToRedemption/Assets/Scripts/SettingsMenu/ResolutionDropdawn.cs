using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdawn : MonoBehaviour
{
    public Dropdown resolutionDropdown; // ссылка на список с разрешениями на канвасе

    private Resolution[] resolutions; // массив доступных разрешений
   

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