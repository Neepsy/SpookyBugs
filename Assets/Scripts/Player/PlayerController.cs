using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using System;

public class PlayerController : MonoBehaviour
{
    public event Action<Puzzle_Interaction_Trigger> OnEnter;
    public event Action OnExit;
   
    public float moveSpeed = 0.02f;
    // public float acceleration = 2f;
    public float jumpPower = 2.0f;
    public float mMouseLookSensitivity = 0.05f;
    public float mVerticalSpeed = 0f;

    private CharacterController controller;
    private Vector3 movement;
    private PlayerInput input;
    private CameraLook cameraController;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        input = gameObject.GetComponent<PlayerInput>();
        cameraController = gameObject.GetComponentInChildren<CameraLook>();


        input.actions["Jump"].performed += context => OnJump(context);
        input.actions["Settings"].performed += context => OnSettings(context);


    }

    // Update is called once per frame
    void Update()
    {
        OnMove(input.actions["Move"].ReadValue<Vector2>());
        OnMouseLook(input.actions["Look"].ReadValue<Vector2>());
    }

    //Adding gravity
    void FixedUpdate()
    {
        if (controller.isGrounded && mVerticalSpeed < 0f)
        {
            mVerticalSpeed = 0f;
        }
        else
        {
            mVerticalSpeed += Physics.gravity.y * Time.deltaTime;
        }

        Vector3 fMove = new Vector3(0, mVerticalSpeed, 0);
        controller.Move(fMove * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Enter-p");
        
        var trigger = collision.gameObject.GetComponent<Puzzle_Interaction_Trigger>();
        if(trigger == null)
        {
            return;
        }
        OnEnter?.Invoke(trigger);
    }

    void OnTriggerExit(Collider collision)
    {
        Debug.Log("LOL-p");
       
        OnExit?.Invoke();
    }

    private void OnMove(Vector2 input)
    { 
        Vector3 targetMovement = new Vector3(input.x, 0, input.y);
        targetMovement = transform.TransformDirection(targetMovement);

        // (De)accelerate actual movement towards input value
		// moves like your on ice
        //movement = Vector3.MoveTowards(movement, targetMovement, acceleration * Time.deltaTime);
		//controller.Move(movement * moveSpeed);
		// moves like your not on ice
		movement = targetMovement.normalized * moveSpeed * Time.deltaTime;
		controller.Move(movement);
    }

    private void OnMouseLook(Vector2 pInput)
    {
        Vector2 fScaledInput = pInput * mMouseLookSensitivity;

        Quaternion PlayerXRotation = cameraController.UpdateCameraRotation(fScaledInput);
        transform.localRotation = PlayerXRotation.normalized;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //TODO: Are we even implementing jump?
        Debug.Log("Jump pressed");
    }

    private void OnSettings(InputAction.CallbackContext context)
    {
        //TODO: Open settings panel
        Debug.Log("Settings toggled");
    }
}
