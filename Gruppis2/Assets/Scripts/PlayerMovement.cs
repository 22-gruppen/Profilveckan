using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 3f;
    public float runSpeed = 7f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    public float maxStamina = 100f; // Maximum stamina
    public float currentStamina; // Current stamina
    public float staminaRegenRate = 5f; // Stamina regeneration rate per second
    public float staminaDepletionRate = 30f;
    public Slider barImage;
    public GameObject other; 
    
   

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentStamina = maxStamina; // Initialize stamina to its maximum value

        // Start the coroutine for delayed stamina regeneration
        StartCoroutine(DelayedStaminaRegen());
    }

    


    void Update()
    {
        // Drain stamina when running
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && canMove;
        float speed = isRunning && currentStamina > 0 ? runSpeed : walkSpeed;

        if (isRunning && currentStamina > 0)
        {
            currentStamina -= staminaDepletionRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
        else if (currentStamina < maxStamina)
        {
            // No stamina regeneration while running
            if (!isRunning)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            }
        }

        if (currentStamina == 0)
        {
            // If stamina is zero, revert to walk speed
            speed = walkSpeed;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;
            speed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Update stamina UI
        if (barImage != null)
        {
            barImage.value = currentStamina / maxStamina;
        }

        



    }

    // Coroutine for delayed stamina regeneration
    IEnumerator DelayedStaminaRegen()
    {
        yield return new WaitForSeconds(5f);
        while (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            yield return null;
        }
    }
    
         void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Train")
            {
                // Assuming the player is the object with this script
               Debug.Log("Player entered the Train trigger zone");
                transform.parent = other.transform;
           }
        } 

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Train")
            {
                Debug.Log("Player exited the Train trigger zone");
                // Assuming the player is the object with this script
                transform.parent = null;
            }
        }
    



}
