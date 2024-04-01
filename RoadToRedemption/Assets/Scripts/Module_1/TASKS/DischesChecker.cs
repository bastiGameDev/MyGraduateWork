using UnityEngine;
using System.Collections.Generic;

public class DishChecker : MonoBehaviour
{
    private HashSet<string> _dishesInSink = new HashSet<string>(); // Множество для хранения имен объектов посуды в раковине
    public List<string> requiredDishNames; // Список имен необходимых предметов посуды

    [SerializeField] private ActionControll actionControll;
    [SerializeField] private AudioSource soundCompleted;

    private void Awake()
    {
        ActionControll actionControll = new ActionControll();
    }

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли входящий объект посудой и добавляем его в коллекцию
        string dishName = other.gameObject.name;
        if (requiredDishNames.Contains(dishName))
        {
            _dishesInSink.Add(dishName);
            CheckRequiredDishes();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Проверяем, является ли выходящий объект посудой и удаляем его из коллекции
        string dishName = other.gameObject.name;
        if (requiredDishNames.Contains(dishName))
        {
            _dishesInSink.Remove(dishName);
            CheckRequiredDishes();
        }
    }

    void CheckRequiredDishes()
    {
        // Проверяем, есть ли все необходимые предметы посуды в раковине
        bool allRequiredDishesInSink = true;
        foreach (string requiredDishName in requiredDishNames)
        {
            if (!_dishesInSink.Contains(requiredDishName))
            {
                allRequiredDishesInSink = false;
                break;
            }
        }

        // Если все необходимые предметы посуды находятся в раковине, выполняем действие
        if (allRequiredDishesInSink)
        {
            Debug.Log("Все необходимые предметы посуды находятся в раковине!");
            
            soundCompleted.Play();

            actionControll.IsCompletedSecondScript = true;
            actionControll.RefreshStates();

        }
    }
}