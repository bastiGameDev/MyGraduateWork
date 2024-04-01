using UnityEngine;

public class BackroomsController : MonoBehaviour
{
    [SerializeField] private FadeOutScreen _fadeOutScreen;
    void Start()
    {
        _fadeOutScreen.StartFadeOut();
    }
}
