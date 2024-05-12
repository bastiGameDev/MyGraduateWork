using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhyCryActive : MonoBehaviour
{
    [SerializeField] private AudioSource whyCry;
    [SerializeField] private AbDoor abDoor;
    [SerializeField] private GameObject audioBox;

    [SerializeField] private FadeOutScreen fadeOutScreen;
    [SerializeField] private AudioSource endMusic;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject endTitles;
    [SerializeField] private TypewriterEffectTMP writerEnd;

    [SerializeField] private string textEnding1 = "\tЛетом 2020 года молодой водитель по имени Дмитрий в состоянии алкогольного опьянения управлял автомобилем Honda. На Ленинском проспекте столицы он не справился с управлением, въехав на большой скорости автомобилю Mercedes-Benz в заднюю часть. Пассажиры и водитель Mercedes не пострадали. Дмитрия врачи спасти не смогли, он умер в больнице. ";
    [SerializeField] private string textEnding2 = "";
    
    
    private void OnTriggerEnter(Collider other)
    {
        endMusic.Play();
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

        yield return new WaitForSeconds(2.1f);
        player.GetComponent<FirstPersonMovement>().enabled = false;

        endTitles.SetActive(true);
        writerEnd.StartWritterText();
        
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("mainScene");
    }
}
