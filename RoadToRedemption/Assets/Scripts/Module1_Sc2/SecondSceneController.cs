using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSceneController : MonoBehaviour
{
    [SerializeField] private GameObject flyObjects;
    [SerializeField] private AudioSource soundScary;

    [SerializeField] private AudioSource creepyMusic;
    [SerializeField] private GameObject lights;
    
    [SerializeField] private AudioSource environment;

    private void Awake()
    {
        flyObjects.gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(ScaryFold());
    }

    private IEnumerator ScaryFold()
    {
        Debug.Log("Coroutine is started for 10s..");
        
        yield return new WaitForSeconds(10);
        
        lights.SetActive(false);
        
        soundScary.Play();
        
        flyObjects.SetActive(true);
        
        environment.Pause();
        
        yield return new WaitForSeconds(5);
        
        creepyMusic.Play();
        
        
        
    }
}
