using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleContoll : MonoBehaviour, IInterectable
{
    [SerializeField] private AudioSource swallowingSound;
    public string GetDescription()
    {
        return "<color=green>Нажмите, что бы выпить</color>";
        
    }
    public void Interact()
    {
        swallowingSound.Play();
        Debug.Log("Drink...");
        gameObject.SetActive(false);
        
    }
}
