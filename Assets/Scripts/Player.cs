using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    private bool spaceKeyIsPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private float rotationSpeed;




    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // JUMP if (Input.GetKeyDown(KeyCode.Space) == true) GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceKeyIsPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

    
        if (spaceKeyIsPressed == true)
        // med eller utan ==true, både funkar.
        {
            rigidbodyComponent.AddForce(Vector3.up * 4, ForceMode.VelocityChange);
            spaceKeyIsPressed = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

    }



    private void FixedUpdate()
    {


    }


}
