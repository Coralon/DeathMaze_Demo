using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private Rigidbody playerRigidbody;
    private float playerSpeed = 7;
    public float horizontalInput;
    public float verticalInput;
    private bool isGrounded = true;
    private int superJumps;
    private bool jumpKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per rendered frame
    // Process player input here to avoid missing capture
    void Update()
    {
        // Get player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;

        }

    }

    // FixedUpdate is called at a default of 100 times per second
    // Process physics here
    private void FixedUpdate()
    {
        //Check if the player is on the ground using physics collider
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        // Move the player with physics
        playerRigidbody.velocity = new Vector3(horizontalInput * playerSpeed, playerRigidbody.velocity.y, verticalInput * playerSpeed);

        // Move the player with transform translate
        //transform.Translate(horizontalInput * playerSpeed * Time.deltaTime, 0, verticalInput * playerSpeed * Time.deltaTime);

        // Jump
        if (jumpKeyPressed)
        {
            float jumpForce = 7;
            if (superJumps > 0)
            {
                jumpForce *= 1.5f;
                superJumps--;
            }
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpKeyPressed = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            //Do something with powerups here
            superJumps++;
            Destroy(other.gameObject);
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    */
}
