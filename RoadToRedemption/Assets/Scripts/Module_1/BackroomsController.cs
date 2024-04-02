using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackroomsController : MonoBehaviour
{
    [SerializeField] private FadeOutScreen _fadeOutScreen;
    [SerializeField] private GameObject player;
    
    public Image imageTask;
    public GameObject cameraObject;
    [SerializeField] private AudioSource soundDie;
    [SerializeField] private GameObject soundBoxEnviroment;
    [SerializeField] private AudioSource musicEnd;
    
    void Start()
    { 
        _fadeOutScreen.StartFadeIn();
        
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

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);

        player.GetComponent<FirstPersonMovement>().enabled = false;
        
        soundDie.Play();
        _fadeOutScreen.StartFadeOut();
        
        yield return new WaitForSeconds(9);
        soundBoxEnviroment.gameObject.SetActive(false);
        
        musicEnd.Play();
    }
    
    
}
