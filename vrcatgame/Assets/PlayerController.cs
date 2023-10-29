using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public XRNode leftInputSource; // Specify the hand (Left or Right) for rotation
    public XRNode rightInputSource; // Specify the hand (Left or Right) for movement
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 45.0f; // Adjust the rotation speed as needed

    private CharacterController characterController;
    private Vector2 leftThumbstickInput;
    private Vector2 rightThumbstickInput;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        InputDevices.GetDeviceAtXRNode(leftInputSource).TryGetFeatureValue(CommonUsages.primary2DAxis, out leftThumbstickInput);
        InputDevices.GetDeviceAtXRNode(rightInputSource).TryGetFeatureValue(CommonUsages.primary2DAxis, out rightThumbstickInput);

        // Rotation
        float rotationInput = rightThumbstickInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationInput, 0);

        // Calculate the movement direction
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 moveDirection = (forward * leftThumbstickInput.y + right * leftThumbstickInput.x).normalized;

        // Movement
        Vector3 movement = moveDirection * movementSpeed;
        characterController.Move(movement * Time.deltaTime);
    }
}