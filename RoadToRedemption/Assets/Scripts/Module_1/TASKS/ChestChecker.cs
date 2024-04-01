using UnityEngine;

public class ChestChecker : MonoBehaviour
{
    [SerializeField] private AudioSource soundCompleted;

    [SerializeField] private ActionControll actionControll;
    [SerializeField] private AudioSource voiceover_6;
    private void Awake()
    {
        ActionControll actionControll = new ActionControll();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("PFB_Lamp_TASK"))
        {
            soundCompleted.Play();

            other.gameObject.tag = "Untagged";

            actionControll.IsCompletedSecondScript = true;
            
            voiceover_6.Play();
            
            actionControll.IsCompletedThirdScript = true;
            actionControll.RefreshStates();
        }
    }
}
