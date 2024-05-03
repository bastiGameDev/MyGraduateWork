using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CryActivetor : MonoBehaviour
{
    [SerializeField] private AudioSource cry;
    private void OnTriggerEnter(Collider other)
    {
        cry.Play();
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
