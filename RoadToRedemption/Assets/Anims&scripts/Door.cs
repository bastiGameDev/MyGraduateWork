using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInterectable

{
    [SerializeField] private AudioSource soundDoorOpen;
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
        if (isOpen) return "Нажмите [E] для <color=green>открытия</color> двери";
        return "Нажмите [E] для <color=red>закрытия</color> двери";
    }

    public void Interact()
    {
        soundDoorOpen.Play();
        
        isOpen = !isOpen;
        if (isOpen)
            m_Animator.SetBool("isOpen", true);
        else
            m_Animator.SetBool("isOpen", false);
        
        
    }


}
