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

    private CharacterController charController;
    bool isJumping;
    float movementSpeed;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
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

        Debug.Log("Movement stuff: " + vertInput + ", " + horiInput);

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horiInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * movementSpeed); //SimpleMove applies the time.deltaTime so I don't gotta

        if (vertInput != 0 || horiInput != 0)
        {
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);
        }
    }

    bool OnSlope()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
        }

        return false;
    }
}
