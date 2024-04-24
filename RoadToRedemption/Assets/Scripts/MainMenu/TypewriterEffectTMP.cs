using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffectTMP : MonoBehaviour
{
    public float delay;
    public string fullText = "";
    private string currentText = "";
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private AudioSource keyboadrEffect;

    public void StartWritterText()
    {
        //textComponent = GetComponent<TextMeshProUGUI>();
        //keyboadrEffect.Play();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}