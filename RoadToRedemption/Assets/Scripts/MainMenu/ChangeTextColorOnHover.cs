using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeTextColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Ссылка на компонент Button
    public Button button;

    // Ссылка на компонент Text внутри кнопки
    public TextMeshProUGUI buttonText;  // Теперь это public, вы можете установить его в инспекторе Unity

    // Цвет текста при обычном состоянии кнопки
    private Color normalTextColor;

    // Цвет текста при наведении курсора
    public Color hoverTextColor = Color.red; // Вы можете изменить этот цвет по вашему выбору

    void Start()
    {
        // Проверяем, что button не равен null
        if (button != null)
        {
            // Если buttonText равен null, попробуйте найти Text напрямую в текущем объекте
            if (buttonText == null)
            {
                buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            }

            // Проверяем, что buttonText не равен null
            if (buttonText != null)
            {
                // Сохраняем цвет текста при обычном состоянии кнопки
                normalTextColor = buttonText.color;
            }
            else
            {
                Debug.LogError("Text not found on the Button or its children.");
            }
        }
        else
        {
            Debug.LogError("Button reference not set in the inspector.");
        }
    }

    // Вызывается при наведении курсора
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Изменяем цвет текста на цвет при наведении
        if (buttonText != null)
        {
            buttonText.color = hoverTextColor;
        }
    }

    // Вызывается при уходе курсора
    public void OnPointerExit(PointerEventData eventData)
    {
        // Возвращаем цвет текста к обычному цвету
        if (buttonText != null)
        {
            buttonText.color = normalTextColor;
        }
    }
}