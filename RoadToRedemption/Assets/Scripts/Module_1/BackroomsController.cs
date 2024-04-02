using UnityEngine;
using UnityEngine.UI;

public class BackroomsController : MonoBehaviour
{
    [SerializeField] private FadeOutScreen _fadeOutScreen;
    public Image imageTask;
    
    void Start()
    {
       // _fadeOutScreen.StartFadeOut();
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
}
