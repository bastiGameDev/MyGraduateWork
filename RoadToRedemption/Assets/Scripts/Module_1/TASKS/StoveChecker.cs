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
        yield return new WaitForSeconds(10);
        
        actionControll.EndingTasks();

        
    }

}
