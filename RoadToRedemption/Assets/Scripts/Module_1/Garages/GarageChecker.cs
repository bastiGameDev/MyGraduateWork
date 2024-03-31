using UnityEngine;

public class GarageChecker : MonoBehaviour
{
    [SerializeField] private ActionControll actionControll;

    [SerializeField] private GameObject bedMarker;
    [SerializeField] private GameObject teapot;
    private void OnTriggerEnter(Collider other)
    {
        bedMarker.SetActive(true);
        teapot.SetActive(false);
        
        actionControll.EndingGarage();
    }
}
