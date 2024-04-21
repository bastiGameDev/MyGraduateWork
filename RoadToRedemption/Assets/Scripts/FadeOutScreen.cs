using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutScreen : MonoBehaviour
{
    public float fadeDuration = 2f; 
    public GameObject screenObject; 

    private Image screenImage; 

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

    public void StartFadeIn()
    {
        // Проверяем, есть ли ссылка на объект экрана
        if (screenObject == null)
        {
            // Если нет, выводим сообщение об ошибке
            Debug.LogError("Screen Object not assigned. Assign the screen GameObject manually.");
            return;
        }

        // Получаем компонент Image с объекта экрана
        screenImage = screenObject.GetComponent<Image>();

        // Проверяем, есть ли компонент Image
        if (screenImage == null)
        {
            // Если нет, выводим сообщение об ошибке
            Debug.LogError("Image component not found on the screen GameObject.");
            return;
        }

        // Запускаем корутину для анимации проявления экрана
        StartCoroutine(FadeInScreenCoroutine());
    }

    private IEnumerator FadeOutScreenCoroutine()
    {
        float timer = 0f;

        // Постепенно увеличиваем прозрачность экрана до 1 (черный цвет)
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            screenImage.color = new Color(0f, 0f, 0f, alpha); // Черный цвет
            timer += Time.deltaTime;
            yield return null;
        }

        // Убеждаемся, что прозрачность установлена в 1 после завершения анимации
        screenImage.color = new Color(0f, 0f, 0f, 1f);
    }

    private IEnumerator FadeInScreenCoroutine()
    {
        float timer = fadeDuration;

        // Постепенно уменьшаем прозрачность экрана до 0 (полная прозрачность)
        while (timer > 0f)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            screenImage.color = new Color(0f, 0f, 0f, alpha); // Черный цвет
            timer -= Time.deltaTime;
            yield return null;
        }

        // Убеждаемся, что прозрачность установлена в 0 после завершения анимации
        screenImage.color = new Color(0f, 0f, 0f, 0f);
    }
}
