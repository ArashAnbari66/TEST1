using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewMovement : MonoBehaviour


{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private float jumpForce = 5f;

    public float distToGround = 1f;
    [SerializeField] private LayerMask groundMask;
    

    private Vector3 movement;

    private Rigidbody playerBody;

    bool shouldJump = false;
    [SerializeField] private bool grounded = false;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(0, playerBody.velocity.y, z * speed);
        movement.Normalize();

        transform.Translate(movement * Time.deltaTime);


        if (Input.GetAxis("Horizontal") != 0f)
        {
            transform.Rotate(Vector3.up * x * (rotationSpeed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            shouldJump = true;
        }


        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.2f, groundMask))
        {
            grounded = true;
        }
        else
        {
   
            grounded = false;
        }

        if (grounded)
        {
            speed = 1f;
        }
        else
        {
            speed = 3f;
        }

    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + (movement * speed * Time.fixedDeltaTime);
        playerBody.MovePosition(newPosition);

        if (shouldJump)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            shouldJump = false;
            
        }
    }
   
}
