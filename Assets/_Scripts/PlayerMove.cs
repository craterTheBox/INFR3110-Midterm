using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 5.0f;
    [SerializeField] private float runBuildUpSpeed = 50.0f;

    private float slopeForce = 6.0f;
    private float slopeForceRayLength = 1.5f;
    [SerializeField] private AnimationCurve jumpFalloff;
    [SerializeField] private float jumpMultiplier = 10.0f;

    private CharacterController charController;
    bool isJumping;
    float movementSpeed;

    public CheckpointManager checkmanager;
    SceneSwitcher switcher;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        ResetToCheckpoint();
    }

    void PlayerMovement()
    {
        float vertInput = 0, horiInput = 0;

        if (Input.GetKey(KeyCode.W))
        {
            vertInput = 1.0f;
            movementSpeed = Mathf.Lerp(movementSpeed, baseSpeed, Time.deltaTime * runBuildUpSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertInput = -1.0f;
            movementSpeed = Mathf.Lerp(movementSpeed, baseSpeed, Time.deltaTime * runBuildUpSpeed);
        }
        if (Input.GetKey(KeyCode.D)) 
        { 
            horiInput = 1.0f;
            movementSpeed = Mathf.Lerp(movementSpeed, baseSpeed, Time.deltaTime * runBuildUpSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horiInput = -1.0f;
            movementSpeed = Mathf.Lerp(movementSpeed, baseSpeed, Time.deltaTime * runBuildUpSpeed);
        }

        //UnityEngine.Debug.Log("Movement stuff: " + vertInput + ", " + horiInput);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horiInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed); //SimpleMove applies the time.deltaTime so I don't gotta

        if (vertInput != 0 || horiInput != 0)
        {
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);
        }

        JumpInput();
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            StartCoroutine(JumpEvent());
        }
    }

    
    IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFalloff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;

    }
    

    private void OnTriggerStay(Collider other)
    {
        UnityEngine.Debug.Log("Colliding with " + other.gameObject.name);
        if (other.gameObject.tag == "Kill")
            checkmanager.Respawn();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Kill")
            checkmanager.Respawn();
    }

    void ResetToCheckpoint()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            checkmanager.Respawn();
        }
    }

    void BackToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switcher.SceneLoad("Start Scene");
        }
    }
}
