using System;
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

    [SerializeField] private string textEnding1 = "\tЛетом 2020 года молодой водитель по имени Дмитрий в состоянии сильного алкогольного опьянения управлял автомобилем Honda. На Ленинском проспекте столицы он не справился с управлением, въехав на большой скорости автомобилю Mercedes-Benz в заднюю часть. Погибли невиновные водитель и пассажиры белого Mercedes. Дмитрий погиб на месте";
    [SerializeField] private string textEnding2 = "\tЛетом 2020 года молодой водитель по имени Дмитрий в состоянии алкогольного опьянения управлял автомобилем Honda. На Ленинском проспекте столицы он не справился с управлением, въехав на большой скорости автомобилю Mercedes-Benz в заднюю часть. Водитель и пассажиры белого Mercedes не пострадали. Дмитрия врачи спасти не смогли, он скончался в больнице. ";
    [SerializeField] private string textEnding3 = "\tЛетом 2020 года молодой водитель по имени Дмитрий в состоянии алкогольного опьянения управлял автомобилем Honda. На Ленинском проспекте столицы он не справился с управлением, въехав автомобилю Mercedes-Benz в заднюю часть. Водитель и пассажиры белого Mercedes не пострадали. Дмитрий также выжил, но получил инвалидность на всю жизнь. ";
    
    private void OnTriggerEnter(Collider other)
    {
        endMusic.Play();
        StartCoroutine(StartVoiceover());
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("Score", 40);
        Debug.Log(PlayerPrefs.GetInt("Score"));
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
        
        if (PlayerPrefs.GetInt("Score") <= 20)
        {
            writerEnd.fullText = textEnding3;
        } 
        else if (PlayerPrefs.GetInt("Score") > 20 && PlayerPrefs.GetInt("Score") <= 40)
        {
            writerEnd.fullText = textEnding2;
        } 
        else if (PlayerPrefs.GetInt("Score") > 40)
        {
            writerEnd.fullText = textEnding1;
        }
        
        writerEnd.StartWritterText();
        
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("mainScene");
    }
}
