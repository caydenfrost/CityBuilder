using UnityEngine;

public class GoHome : MonoBehaviour
{
    private GameObject selectedCharacter;
    private Vector3 initialMousePosition;
    private Vector3 initialCharacterPosition;
    private bool isDragging = false;
    public float dragSpeed = 0.1f; // Adjust this value to control the movement speed during dragging
    void Start()
    {
        
    }
    void Update()
    {
        // Handle mouse drag to move character
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject) // Check if clicked object is the character
                {
                    selectedCharacter = gameObject;
                    initialMousePosition = Input.mousePosition;
                    initialCharacterPosition = transform.position;
                    isDragging = true;
                }
            }
        }
        else if (Input.GetMouseButton(0) && isDragging && selectedCharacter != null)
        {
            Vector3 currentMousePosition = Input.mousePosition;

            // Convert mouse position to world space
            Ray ray = Camera.main.ScreenPointToRay(currentMousePosition);
            Plane plane = new Plane(Vector3.up, initialCharacterPosition);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 targetPosition = ray.GetPoint(distance);
                selectedCharacter.transform.position = targetPosition;
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
        }
    }

    // Cancel Selection
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedCharacter = null;
            // Reset appearance or perform any other actions to indicate deselection
        }
    }
}