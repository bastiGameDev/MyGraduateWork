using TMPro;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] private Transform handTransform; // Ссылка на трансформ рук персонажа
    private GameObject carriedObject; // Ссылка на поднимаемый объект

    [SerializeField] private float pickupDistance = 5f; // Максимальное расстояние для подбора объекта
    [SerializeField] private AudioSource soundPick;
    
   // [SerializeField] private TextMeshProUGUI interactionText;

    void Update()
    {
        // Если объект не поднимается и нажата кнопка для подбора объекта
        if (carriedObject == null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            // Используем pickupDistance вместо жестко заданного значения
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
            {
                //string objectName = hit.collider.gameObject.name;
                //interactionText.text = objectName;
                
                if (hit.collider.CompareTag("PickUp"))
                {
                    // Поднимаем объект
                    soundPick.Play();
                    carriedObject = hit.collider.gameObject;
                    // Отключаем компонент коллайдера объекта
                    Collider objCollider = carriedObject.GetComponent<Collider>();
                    if (objCollider != null)
                        objCollider.enabled = false;
                    carriedObject.GetComponent<Rigidbody>().isKinematic = true;
                    carriedObject.transform.parent = handTransform;
                    carriedObject.transform.localPosition = Vector3.zero;
                    carriedObject.transform.localRotation = Quaternion.identity;
                }
            }
        }
        // Если объект поднимается и нажата кнопка для отпускания объекта
        else if (carriedObject != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Отпускаем объект
            // Включаем компонент коллайдера объекта
            Collider objCollider = carriedObject.GetComponent<Collider>();
            if (objCollider != null)
                objCollider.enabled = true;
            carriedObject.GetComponent<Rigidbody>().isKinematic = false;
            carriedObject.transform.parent = null;
            carriedObject = null;
        }
    }
}
