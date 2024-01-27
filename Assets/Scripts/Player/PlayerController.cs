using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 0.02f;
    public float acceleration = 2f;
    public float jumpPower = 2.0f;


    private CharacterController controller;
    private Vector3 movement;
    private PlayerInput input;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        input = gameObject.GetComponent<PlayerInput>();


        input.actions["Jump"].performed += context => OnJump(context);
    }

    // Update is called once per frame
    void Update()
    {
        OnMove(input.actions["Move"].ReadValue<Vector2>());
    }

    private void OnMove(Vector2 input)
    {
        Vector3 targetMovement = new Vector3(input.x, 0, input.y);

        // (De)accelerate actual movement towards input value
        movement = Vector3.MoveTowards(movement, targetMovement, acceleration * Time.deltaTime);
        controller.Move(movement * moveSpeed);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //TODO: Are we even implementing jump?
        Debug.Log("Jump pressed");
    }
}
