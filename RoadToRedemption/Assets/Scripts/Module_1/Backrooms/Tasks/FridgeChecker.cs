using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeChecker : MonoBehaviour, IInterectable
{
    [SerializeField] private AudioSource soundPick;
    public string GetDescription()
    {

        return "Нажмите для cбора";
    }
    
    public void Interact()
    {
        soundPick.Play();
        gameObject.SetActive(false);
    }
}
