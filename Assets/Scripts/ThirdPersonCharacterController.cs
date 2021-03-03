using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ThirdPersonCharacterController : NetworkBehaviour
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

    [Header("References")]
    public Camera playerCamera;

    private void Awake()
    {
        lpInput = GetComponent<LocalPlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerCamera.gameObject.SetActive(isLocalPlayer);

        // if not local player, return
        if (!isLocalPlayer) return;

        isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundCheckMask).Length > 0;
        if (isGrounded && lpInput.jumpInput)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate()
    {
        // if not local player, return
        if (!isLocalPlayer) return;

        rb.transform.Translate((lpInput.moveInput * speed * Time.deltaTime), Space.Self);
    }
}
