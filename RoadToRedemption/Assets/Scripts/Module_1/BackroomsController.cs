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
    
    void Start()
    {
       // _fadeOutScreen.StartFadeOut();
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
        yield return new WaitForSeconds(10);

        player.GetComponent<FirstPersonMovement>().enabled = false;
        GetComponent<Camera>().GetComponent<FirstPersonLook>().enabled = false;
        
        soundDie.Play();
        _fadeOutScreen.StartFadeOut();
        
        yield return new WaitForSeconds(7);
    }
    
    private void RotateDown()
    {
        transform.rotation = Quaternion.LookRotation(-Vector3.up);
    }
}
