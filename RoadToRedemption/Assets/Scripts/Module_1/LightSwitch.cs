using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSwitch : MonoBehaviour, IInterectable
{
    [SerializeField] private Light m_Light;
    [SerializeField] private GameObject gameObjectLight;
    [FormerlySerializedAs("_isOn")] [SerializeField] private bool isOn;
    private void Start()
    {
        m_Light.enabled = isOn;
    }

    public string GetDescription()
    {
        if (isOn) return "Нажмите [E] для <color=red>выключения</color> света";
        return "Нажмите [E] для <color=green>включения</color> света";
    }

    public void Interact()
    {
        isOn = !isOn;
        //m_Light.enabled = isOn;
        gameObjectLight.SetActive(isOn);
    }
}
