using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    private LocalPlayerInput lpInput;
    private Rigidbody rb;

    [Header("Movement")]
    public float speed;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;
    public float jumpForce;

    void Awake()
    {
        lpInput = GetComponent<LocalPlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundCheckMask).Length > 0;
        if (isGrounded && lpInput.jumpInput)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        rb.transform.Translate((lpInput.moveInput * speed * Time.deltaTime), Space.Self);
    }
}
