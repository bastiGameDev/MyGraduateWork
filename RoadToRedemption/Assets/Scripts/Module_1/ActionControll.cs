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
