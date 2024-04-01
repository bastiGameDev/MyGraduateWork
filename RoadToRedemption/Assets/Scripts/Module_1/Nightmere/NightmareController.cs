using System;
using UnityEngine;

public class NightmareController : MonoBehaviour
{
    [SerializeField] private FadeOutScreen _fadeOutScreen;

    private void Start()
    {
        _fadeOutScreen.StartFadeIn();
    }
}
