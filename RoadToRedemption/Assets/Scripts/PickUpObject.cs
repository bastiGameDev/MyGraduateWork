using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform handTransform; // Ссылка на трансформ рук персонажа
    private GameObject carriedObject; // Ссылка на поднимаемый объект

    public float pickupDistance = 5f; // Максимальное расстояние для подбора объекта

    void Update()
    {
        // Если объект не поднимается и нажата кнопка для подбора объекта
        if (carriedObject == null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            // Используем pickupDistance вместо жестко заданного значения
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
            {
                if (hit.collider.CompareTag("PickUp"))
                {
                    // Поднимаем объект
                    carriedObject = hit.collider.gameObject;
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
            carriedObject.GetComponent<Rigidbody>().isKinematic = false;
            carriedObject.transform.parent = null;
            carriedObject = null;
        }
    }
}