using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    private Animator _animator;

    [SerializeField] public float _playerSpeed = 2f;

    [SerializeField] private float _rotationSpeed = 4f;

    private float startY;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = transform.GetChild(0).GetComponent<Animator>();        
        startY = 1.241f;
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        _animator.SetFloat("speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        _controller.Move(new Vector3(movementDirection.x, 0, movementDirection.z) * _playerSpeed * Time.deltaTime);

        if(transform.position.y != startY)
        {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}
