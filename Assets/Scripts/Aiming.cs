using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Get reference to the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to a ray in world space
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        // Perform a raycast to determine the point in the world the ray hits
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Get the direction from the player's position to the hit point
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // Ignore any vertical offset

            // Rotate the player to face the direction
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
