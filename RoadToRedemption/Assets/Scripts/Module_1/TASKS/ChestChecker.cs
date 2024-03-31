using UnityEngine;

public class ChestChecker : MonoBehaviour
{
    [SerializeField] private AudioSource soundCompleted;

    [SerializeField] private ActionControll actionControll;
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
            
            
            
            
        }
    }
}
