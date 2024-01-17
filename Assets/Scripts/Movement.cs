using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 180f;

    private CharacterController characterController;

    void Start()
    {
        // Assuming you have a CharacterController component attached to the GameObject
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check if there is any input, then move and rotate the character
        if (movementDirection.magnitude >= 0.1f)
        {
            // Calculate rotation towards the movement direction
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            // Move the character in the movement direction
            Vector3 moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            characterController.Move(moveDirection * movementSpeed * Time.deltaTime);

            // Rotate the character towards the movement direction
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
