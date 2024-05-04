using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackroomsController : MonoBehaviour
{
    [Header("Backrooms")] 
    [SerializeField] private FadeOutScreen _fadeOutScreen;
    [SerializeField] private GameObject player;
    
    public Image imageTask;
    public GameObject cameraObject;
    [SerializeField] private AudioSource soundDie;
    [SerializeField] private GameObject soundBoxEnviroment;
    [SerializeField] private AudioSource musicEnd;
    [SerializeField] private TypewriterEffectTMP typeText;
    [SerializeField] private GameObject textTitles;

    [Header("ForEndGame")] 
    [SerializeField] private GameObject imageOperatingRoom;
    [SerializeField] private AudioSource operatingRoomSound;
    [SerializeField] private TypewriterEffectTMP typeTask;
    
    
    
    
    
    void Start()
    {
        StartCoroutine(StartGame());
        StartCoroutine(EndGame());
    }
    
    private void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.Tab))
        {
            imageTask.gameObject.SetActive(true);
        }
        else
        {
            imageTask.gameObject.SetActive(false);
        }
    }

    IEnumerator StartGame()
    {
        typeText.StartWritterText();
        
        yield return new WaitForSeconds(2f);
        
        _fadeOutScreen.StartFadeIn();
        
        yield return new WaitForSeconds(3f);
        
        textTitles.SetActive(false);
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);//

        player.GetComponent<FirstPersonMovement>().enabled = false;
        
        soundDie.Play();
        _fadeOutScreen.StartFadeOut();
        
        yield return new WaitForSeconds(5);
        imageOperatingRoom.SetActive(true);
        soundBoxEnviroment.gameObject.SetActive(false);
        _fadeOutScreen.StartFadeIn();
        yield return new WaitForSeconds(5);
        operatingRoomSound.Play();
        
        _fadeOutScreen.StartFadeOut();
        
        Debug.Log("End");
        operatingRoomSound.Pause();
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scene_5");
    }
    
    
}
