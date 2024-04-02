using UnityEngine;

public class HouseChecker : MonoBehaviour
{
    [SerializeField] private GameObject house;
    [SerializeField] private AudioSource scarySoud;
    private void OnTriggerExit(Collider other)
    {
        scarySoud.Play();
        
        house.gameObject.SetActive(false);
    }
}
