using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveChecker : MonoBehaviour
{
    [SerializeField] private AudioSource gazStove;
    [SerializeField] private AudioSource soundCompleted;

    [SerializeField] private ActionControll actionControll;
    [SerializeField] private GameObject imageCheckMark;
    
    //
    [SerializeField] private GameObject panelChoice; 
    [SerializeField] private GameObject notification;
    [SerializeField] private GameObject fpsController;
    [SerializeField] private GameObject fpsCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Teapot"))
        {
            soundCompleted.Play();
            imageCheckMark.SetActive(true);

            other.gameObject.tag = "Untagged";
            
            gazStove.Play();

            actionControll.IsCompletedThirdScript = true;

            StartCoroutine(StoveWaiter());
        }
    }

    private IEnumerator StoveWaiter()
    {
        Debug.Log("CS");
        //Здесь голос что надо подождать чай
        
        //Затухание экрана и переход в гаржаи   
        yield return new WaitForSeconds(6);
        //Здесь окно выбора зайти ли в магазин за пивом//
        panelChoice.SetActive(true);
        
        ShowCursor(true);
        
        FreezeMovement(false);
        //actionControll.EndingTasks(); <-- это переносится в обработчик событиый кнопки панели выборы
    }

    public void FreezeMovement(bool state)
    {
        fpsCamera.GetComponent<FirstPersonLook>().enabled = state;
        fpsCamera.GetComponent<PickUpObject>().enabled = state;
        fpsController.GetComponent<PlayerInteraction>().enabled = state;
    }

    public void ChoiceTrue()
    {
        PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") + 20));
        
        StartCoroutine(ShowHideNotification());
        //PlayerPrefs +score
        actionControll.EndingTasks();
        ShowCursor(false);
        FreezeMovement(true);
    }
    public void ChoiceFalse()
    {
        
        StartCoroutine(ShowHideNotification());
        //PlayerPrefs -score
        actionControll.EndingTasks();
        ShowCursor(false);
        panelChoice.SetActive(false);
        FreezeMovement(true);
    }
    
    private IEnumerator ShowHideNotification()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        notification.SetActive(false);
        gameObject.SetActive(false);
        panelChoice.SetActive(false);
    }
    private void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }

}
