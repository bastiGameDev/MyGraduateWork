using UnityEngine;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{
   [SerializeField] private Camera mainCam;
   public float interactionDistance = 10f;

   [SerializeField] private GameObject interactionUI;
   [SerializeField] private TextMeshProUGUI interactionText;

   private void Update()
   {
      InteractionRay();
   }

   private void InteractionRay()
   {
      Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
      RaycastHit hit;

      bool hitSomething = false;

      if (Physics.Raycast(ray, out hit, interactionDistance))
      {
         IInterectable interectable = hit.collider.GetComponent<IInterectable>();

         if (interectable != null)
         {
            hitSomething = true;
            interactionText.text = interectable.GetDescription();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               interectable.Interact();
            }
         }
      }
      interactionUI.SetActive(hitSomething);
   }
}
