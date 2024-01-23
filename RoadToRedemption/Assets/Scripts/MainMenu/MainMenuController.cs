using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI phraseText;  

    private string[] phrases = {
        "Все мы не вечные",
        "Никто её не ждёт...",
        "Оглянись вокруг, кто все эти люди",
        "Смерть — единственная неизбежность в нашем путешествии.",
        "Смерть — это момент, когда время для нас останавливается.",
        "Всё, что живет, обречено на свою последнюю страницу.",
        "Смерть — тайная дверь, о которой мы узнаем только в конце.",
        "Жизнь — это звучание мгновений, смерть — их таинственное затухание.",
        "Смерть — голос, который научил нас ценить каждое мгновение.",
        
    };

    private void Start()
    {
        StartCoroutine(ChangePhraseRoutine());
    }

    private IEnumerator ChangePhraseRoutine()
    {
        while (true)
        {
            
            string randomPhrase = GetRandomPhrase();

            if (phraseText != null)
            {
                phraseText.text = randomPhrase;
            }

            yield return new WaitForSeconds(6f);
        }
    }

    private string GetRandomPhrase()
    {
        int randomIndex = Random.Range(0, phrases.Length);

        return phrases[randomIndex];
    }
}
