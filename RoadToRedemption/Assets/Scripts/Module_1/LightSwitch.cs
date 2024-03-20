using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSwitch : MonoBehaviour, IInterectable
{
    //[SerializeField] private Light m_Light;
    [SerializeField] private AudioSource soundLightswitch;
    
    [SerializeField] private GameObject m_gameObjectLight;
    [FormerlySerializedAs("_isOn")] [SerializeField] private bool isOn;
    private void Start()
    {
        m_gameObjectLight.SetActive(isOn);
    }

    public string GetDescription()
    {
        if (isOn) return "Нажмите [E] для <color=red>выключения</color> света";
        return "Нажмите [E] для <color=green>включения</color> света";
    }

    public void Interact()
    {
        soundLightswitch.Play();
        
        isOn = !isOn;
        //m_Light.enabled = isOn;
        m_gameObjectLight.SetActive(isOn);
    }
}
