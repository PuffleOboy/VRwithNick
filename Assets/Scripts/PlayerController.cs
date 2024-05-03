using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour

{

    [SerializeField] private InputActionReference jumpActionReference;

    [SerializeField] private float jumpSpeed = 500f;



    //private Rigidbody _body;

    private CharacterController character;



    private Vector3 movingDirection = Vector3.zero;

    public float gravity = 10.0f;

    //public float jumpSpeed = 4.0f;

    private float jumppos;

    public float jumpHeight = 5.0f;

    public bool isJumping = false;



    private bool IsGrounded => Physics.Raycast(

    new Vector2(transform.position.x, transform.position.y + 2.0f),

    Vector3.down, 5.0f);



    void Start()

    {

        //_body = GetComponent<Rigidbody>();

        character = GetComponent<CharacterController>();

        jumpActionReference.action.performed += OnJump;

    }



    // Update is called once per frame

    void Update()

    {
        character.Move(movingDirection * Time.smoothDeltaTime);
        movingDirection.y -= gravity * Time.smoothDeltaTime;
    }



    private void OnJump(InputAction.CallbackContext obj)

    {

        if (!character.isGrounded) return;

        //character.Move(Vector3.up * jumpSpeed * Time.smoothDeltaTime); ;

        if (character.transform.position.y >= jumppos + jumpHeight)

        {

            //movingDirection.y = jumpSpeed;

            //isJumping = false;

            //character.slopeLimit = 45;

        }

        movingDirection.y = jumpSpeed;

        //movingDirection.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);

        //movingDirection.y -= gravity * Time.deltaTime;



    }

}