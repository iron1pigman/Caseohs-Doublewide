using UnityEngine;

public class PlayerC : MonoBehaviour
{
    [SerializeField] public bool canUsePlayerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float playerSpeed;
    [Space]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded;
    [Space]
    [SerializeField] private Transform _camera;
    [SerializeField] private float rotationSpeed = 5.0f;

    private void Start()
    {
        canUsePlayerController = true;
    }

    private void Update()
    {
        if (canUsePlayerController)
        {
            MoveFuntion();
            cameraFunction();
        }
    }
    private void MoveFuntion()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundMask);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;
        rb.MovePosition(transform.position + moveDirection * playerSpeed * Time.deltaTime);
    }
    private void cameraFunction()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(verticalInput, horizontalInput, 0) * rotationSpeed;

        transform.Rotate(rotation);
    }
}
