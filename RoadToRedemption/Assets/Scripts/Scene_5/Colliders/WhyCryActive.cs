using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhyCryActive : MonoBehaviour
{
    [SerializeField] private AudioSource whyCry;
    [SerializeField] private AbDoor abDoor;
    [SerializeField] private GameObject audioBox;

    [SerializeField] private FadeOutScreen fadeOutScreen;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartVoiceover());
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator StartVoiceover()
    {
        yield return new WaitForSeconds(1.5f);
        whyCry.Play();
        yield return new WaitForSeconds(0.4f);

        abDoor.isOpen = true;
        abDoor.Interact();

        yield return new WaitForSeconds(5f);
        fadeOutScreen.StartFadeOut();

        audioBox.SetActive(false);
        //И тут уже конец программы
    }
}
