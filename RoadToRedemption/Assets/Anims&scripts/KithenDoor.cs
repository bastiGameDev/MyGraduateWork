using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KithenDoor : MonoBehaviour, IInterectable
{
    [SerializeField] private AudioSource soundKitchenDoor;
    
    public Animator m_Animator;
    public bool isOpen;
    void Start()
    {
        if (isOpen)
        {
            m_Animator.SetBool("isOpen", true);
        }
    }

    public string GetDescription()
    {
        if (isOpen) return "Нажмите [E] для <color=red>закрытия</color> дверцы";
        return "Нажмите [E] для <color=green>открытия</color> дверцы";
    }

    public void Interact()
    {
        soundKitchenDoor.Play();
            
        isOpen = !isOpen;
        if (isOpen)
            m_Animator.SetBool("isOpen", true);
        else
            m_Animator.SetBool("isOpen", false);
        
        
    }
}
