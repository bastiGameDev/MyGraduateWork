using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionControll : MonoBehaviour
{
    private bool _isCompletedFirstScript;
    private bool _isCompletedSecondScript;
    private bool _isCompletedThirdScript;
    private bool _isCompletedFourthScript;

    private bool _isFoundTaskImage;
    
    public Image imageTask;
    
    [SerializeField] private ActionControll actionControll;
    [SerializeField] private FadeOutScreen _fadeOutScreen;
    [SerializeField] private GameObject player;

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

    public void EndingTasks()
    {
        StartCoroutine(TeleportPlayerTo(-1.14999998f, 0.120125294f, 105.279999f));
    }

    public void EndingGarage()
    {
        StartCoroutine(TeleportPlayerTo(-14.4099998f,0.120125294f,42.1199989f));
    }
    
    private IEnumerator TeleportPlayerTo(float x, float y, float z)
    {
        Debug.Log("Start cs");
        _fadeOutScreen.StartFadeOut();
        
        yield return new WaitForSeconds(2.1f);
        
        player.transform.position = new Vector3(x, y, z);
        
        yield return new WaitForSeconds(1f);
        
        _fadeOutScreen.StartFadeIn();

    }

    public bool IsFoundTaskImage
    {
        get => _isFoundTaskImage;
        set => _isFoundTaskImage = value;
    }

    public bool IsCompletedFirstScript
    {
        get => _isCompletedFirstScript;
        set => _isCompletedFirstScript = value;
    }

    public bool IsCompletedSecondScript
    {
        get => _isCompletedSecondScript;
        set => _isCompletedSecondScript = value;
    }

    public bool IsCompletedThirdScript
    {
        get => _isCompletedThirdScript;
        set => _isCompletedThirdScript = value;
    }

    public bool IsCompletedFourthScript
    {
        get => _isCompletedFourthScript;
        set => _isCompletedFourthScript = value;
    }

    
}
