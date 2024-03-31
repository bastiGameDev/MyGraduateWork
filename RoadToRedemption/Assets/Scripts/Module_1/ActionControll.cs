using UnityEngine;

public class ActionControll : MonoBehaviour
{
    [SerializeField] private bool _isCompletedFirstScript;
    private bool _isCompletedSecondScript;
    private bool _isCompletedThirdScript;
    private bool _isCompletedFourthScript;

    private void FixedUpdate()
    {
        
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
