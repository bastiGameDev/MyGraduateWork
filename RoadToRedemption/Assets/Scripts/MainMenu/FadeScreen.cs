using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2f; 
    [SerializeField] private GameObject screenObject;
    
    private Image screenImage;

    [FormerlySerializedAs("TextObjects")] [SerializeField] private GameObject textObjects;

    [SerializeField] private TypewriterEffectTMP _typewriterEffectTMP;

    [SerializeField] private GameObject btnStartGameShow;
    
    public void StartFadeOut()
    {
        if (screenObject == null)
        {
            Debug.LogError("Screen Object not assigned. Assign the screen GameObject manually.");
            return;
        }
        
        screenImage = screenObject.GetComponent<Image>();

        if (screenImage == null)
        {
            Debug.LogError("Image component not found on the screen GameObject.");
            return;
        }

        StartCoroutine(FadeOutScreenCoroutine());
    }
    
    private IEnumerator FadeOutScreenCoroutine()
    {
        screenImage.gameObject.SetActive(true);
        
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            screenImage.color = new Color(0f, 0f, 0f, alpha); 
            timer += Time.deltaTime;
            yield return null;
        }
        
        screenImage.color = new Color(0f, 0f, 0f, 1f);
        
        textObjects.SetActive(true);
        
        _typewriterEffectTMP.StartWritterText();
        
        yield return new WaitForSeconds(12f);
        
        btnStartGameShow.SetActive(true);
        
        Debug.Log("Readed");
    }
}
