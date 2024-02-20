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
        
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!IsGrounded) return;
        character.Move(Vector3.up * jumpSpeed * Time.smoothDeltaTime); ;
    }
}
