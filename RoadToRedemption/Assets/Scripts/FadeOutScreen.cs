using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutScreen : MonoBehaviour
{
    public float fadeDuration = 2f; // Длительность анимации в секундах
    public GameObject screenObject; // Ссылка на объект с компонентом Image (ваш экран)

    private Image screenImage; // Ссылка на компонент Image

    public void StartFadeOut()
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

        // Запускаем корутину для анимации затухания экрана
        StartCoroutine(FadeOutScreenCoroutine());
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
}