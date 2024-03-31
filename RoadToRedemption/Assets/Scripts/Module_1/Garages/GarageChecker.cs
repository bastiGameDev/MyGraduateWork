using UnityEngine;

public class GarageChecker : MonoBehaviour
{
    [SerializeField] private ActionControll actionControll;
    private void OnTriggerEnter(Collider other)
    {
        actionControll.EndingGarage();
    }
}
