using System;
using UnityEngine;
using System.Collections.Generic;

public class DishChecker : MonoBehaviour
{
    private HashSet<string> _dishesInSink = new HashSet<string>(); 
    public List<string> requiredDishNames; 

    [SerializeField] private ActionControll actionControll;
    [SerializeField] private AudioSource soundCompleted;
    [SerializeField] private GameObject imageCheckMark;

    private void Awake()
    {
        ActionControll actionControll = new ActionControll();
    }

    void OnTriggerEnter(Collider other)
    {
        string dishName = other.gameObject.name;
        if (requiredDishNames.Contains(dishName))
        {
            _dishesInSink.Add(dishName);
            CheckRequiredDishes();
        }
    }

    void OnTriggerExit(Collider other)
    {
        try
        {
            string dishName = other.gameObject.name;
            if (requiredDishNames.Contains(dishName))
            {
                _dishesInSink.Remove(dishName);
                CheckRequiredDishes();
            }
        }
        catch 
        {
            Debug.LogError("Error");
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

            imageCheckMark.SetActive(true);
            ////////
        }
    }
}