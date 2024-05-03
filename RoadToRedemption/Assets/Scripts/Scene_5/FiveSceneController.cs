using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveSceneController : MonoBehaviour
{
    [SerializeField] private FadeOutScreen _fadeOutScreen;
    [SerializeField] private TypewriterEffectTMP typeWriter;
    [SerializeField] private GameObject taskText;
    private void Start()
    {
        StartCoroutine(StartScene());
    }

    private IEnumerator StartScene()
    {
        typeWriter.StartWritterText();

        yield return new WaitForSeconds(3f);
        
        _fadeOutScreen.StartFadeOut();
        
        yield return new WaitForSeconds(1f);
        
        taskText.gameObject.SetActive(false);
    }
}
