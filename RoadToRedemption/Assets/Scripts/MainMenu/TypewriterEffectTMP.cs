using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffectTMP : MonoBehaviour
{
    public float delay;
    public string fullText = "\tВ 2020 году парень по имени Дмитрий закончил школу, 9 классов. Аттестат забрал, но подавать документы никуда не стал. Начал вести непристойный образ жизни. Обрёл вредные привычки: " +
                             "злоупотреблять алкоголем, курение, и, самое страшное, садиться за руль автомашины в нетрезвом состоянии. Никогда не повторяйте данных действий.";
    private string currentText = "";
    [SerializeField] private TextMeshProUGUI textComponent;

    public void StartWritterText()
    {
        //textComponent = GetComponent<TextMeshProUGUI>();
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