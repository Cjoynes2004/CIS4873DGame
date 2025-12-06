using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float mouseSens;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    [SerializeField] private Camera playerCamera;

    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float pitch;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        UpdateCamera();
    }

    private void MovePlayer()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void UpdateCamera()
    {
        transform.Rotate(Vector3.up * lookInput.x * mouseSens);
        pitch -= lookInput.y * mouseSens;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

}
