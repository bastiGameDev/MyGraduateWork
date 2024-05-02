using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheast : MonoBehaviour, IInterectable
{
    [SerializeField] private AudioSource soundCheast;
    
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
        if (isOpen) return "Нажмите для <color=red>закрытия</color> ящика";
        return "Нажмите для <color=green>открытия</color> ящика";
    }

    public void Interact()
    {
        soundCheast.Play();
            
        isOpen = !isOpen;
        if (isOpen)
            m_Animator.SetBool("isOpen", true);
        else
            m_Animator.SetBool("isOpen", false);
        
        
    }
    
    
}
