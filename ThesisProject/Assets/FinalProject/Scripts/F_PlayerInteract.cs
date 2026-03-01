using UnityEngine;
using UnityEngine.InputSystem;

// Interface for all objects the player can interact with
public interface F_IInteractable
{
    void Interact();
}
public class F_PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float interactRange;

    private void Start()
    {
        playerCamera = Camera.main;
    }
    private void OnInteract(InputValue value)
    {
        // Shooting a ray from our camera
        Ray ray = new Ray
        {
            origin = playerCamera.transform.position,
            direction = playerCamera.transform.forward
        };

        // If you want to see the ray when you press interact button you can uncomment this line of code.
        Debug.DrawRay(ray.origin, ray.direction* interactRange);

        // Saving hit information and checking if we hit an interactable object
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, interactRange))
        {
            F_IInteractable interactable = hitInfo.collider.GetComponent<F_IInteractable>();
            if (interactable != null)
            {
                // Calling interact method of the interactable
                interactable.Interact();
            }
        }
    }
}
