using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheast : MonoBehaviour, IInterectable
{
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
        if (isOpen) return "Нажмите [E] для <color=green>открытия</color> ящика";
        return "Нажмите [E] для <color=red>закрытия</color> ящика";
    }

    public void Interact()
    {
        isOpen = !isOpen;
        if (isOpen)
            m_Animator.SetBool("isOpen", true);
        else
            m_Animator.SetBool("isOpen", false);
        
        
    }
    
    
}
