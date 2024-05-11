using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SettingsManager : MonoBehaviour
{
    public Toggle postProcessingToggle; // ссылка на чекбокс на канвасе
    public PostProcessVolume postProcessVolume; // ссылка на объект PostProcessVolume в сцене

    private void Awake()
    {
        // устанавливаем значение чекбокса в соответствии с текущим состоянием пост-обработки
        postProcessingToggle.isOn = postProcessVolume.enabled;

        // подписываемся на событие изменения значения чекбокса
        postProcessingToggle.onValueChanged.AddListener(OnPostProcessingToggleChanged);
    }

    private void OnPostProcessingToggleChanged(bool isOn)
    {
        // включаем/выключаем пост-обработку в зависимости от значения чекбокса
        postProcessVolume.enabled = isOn;
    }

    private void OnDestroy()
    {
        // отписываемся от события изменения значения чекбокса
        postProcessingToggle.onValueChanged.RemoveListener(OnPostProcessingToggleChanged);
    }
}