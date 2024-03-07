using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public float maxStamina = 100f; // Max stamina
    public float currentStamina; // Nuvarande stamina
    public float staminaRegenRate = 5f; // Hur snabbt den ska g� upp. 
    public float staminaDepletionRate = 30f; // hur snabbt den g�r ner. 
    public Slider staminaImage; // stamina baren


    private Vector3 moveDirection = Vector3.zero; // kollar vilket h�ll den ska r�ra sig mot. 
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    private bool moving = false;

    public AudioSource walk;
    public AudioSource running;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // l�ser muspekaren. 
        Cursor.visible = false; // g�mmer muspekaren. 
        currentStamina = maxStamina; // i b�rjan s� �r nuvarenda stamina och max stamina likadant. 

        // startar nedr�kningen f�r att kunna �ka staminan
        StartCoroutine(DelayedStaminaRegen());
    }




    void Update()
    {
        //  N�R SPRINGER S� F�RSVINNER STAMINA
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && canMove && moving;
        float speed = isRunning && currentStamina > 0 ? runSpeed : walkSpeed;

        if (isRunning && currentStamina > 0)
        {
            currentStamina -= staminaDepletionRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
        else if (currentStamina < maxStamina)
        {
            // �KAR INTE OM DU SPRINGER. 
            if (!isRunning)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            }
        }

        if (currentStamina == 0)
        {
            // OM DU HAR 0 STAMINA S� BLIR DE WALK SPEED. 
            speed = walkSpeed;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // R�RELSE
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        // HOPP
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

        
        

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove) // om du kan r�ra dig s� ger den en gr�ns p� hur l�ngt ner och upp du kan titta. 
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Updaterar stamina bilden s� den r�r p� sig n�r man springer. 
        if (staminaImage != null)
        {
            staminaImage.value = currentStamina / maxStamina;
        }

        if (curSpeedX > 0 && curSpeedY <= 0)
            moving = true;

        else if (curSpeedX <= 0 && curSpeedY <= 0)
            moving = false;

        if (moving == true) // om man r�r sig s� spelar ett walk ljud om slutar g� s� slutar ljudet
        {
            if (walk.isPlaying == false)
            {
                walk.Play();
            }
        }
        else if (moving == false && walk.isPlaying == true)
            walk.Stop();



    }





    IEnumerator DelayedStaminaRegen()
    {
        yield return new WaitForSeconds(5f); // v�ntar 5 sekunder innan den �kar staminan. 
        while (currentStamina < maxStamina) // om max stamina �r st�rre �n nuvarande stamina s� b�rjar den g� upp, 
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
            other.transform.parent = transform;

            // Transfer velocity to the player
            var trainVelocity = other.GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = trainVelocity;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            SceneManager.LoadScene("MainMenu");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Train")
        {
            // Assuming the player is the object with this script
            other.transform.parent = null;
        }
    }
}





