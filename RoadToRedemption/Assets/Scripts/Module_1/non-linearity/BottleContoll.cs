using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleContoll : MonoBehaviour, IInterectable
{
    [SerializeField] private AudioSource swallowingSound;
    [SerializeField] private GameObject notification;
    public string GetDescription()
    {
        return "<color=green>Нажмите, что бы выпить</color>";
        
    }
    public void Interact()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        swallowingSound.Play();
        Debug.Log("Drink...");
        
        StartCoroutine(ShowHideNotification());
        
    }

    public void ShowNotificationForeign()
    {
        StartCoroutine(ShowNotificationForeignRoutine());
    }

    private IEnumerator ShowNotificationForeignRoutine()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        notification.SetActive(false);
    }

    private IEnumerator ShowHideNotification()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        notification.SetActive(false);
        gameObject.SetActive(false);
    }
}
