using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveChecker : MonoBehaviour
{
    [SerializeField] private AudioSource gazStove;
    [SerializeField] private AudioSource soundCompleted;

    [SerializeField] private ActionControll actionControll;
    private void Awake()
    {
        ActionControll actionControll = new ActionControll();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Teapot"))
        {
            soundCompleted.Play();

            other.gameObject.tag = "Untagged";
            
            gazStove.Play();
            
            
        }
    }


}
