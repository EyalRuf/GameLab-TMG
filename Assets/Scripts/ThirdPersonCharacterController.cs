using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using Steamworks;

public class ThirdPersonCharacterController : NetworkBehaviour
{
    private LocalPlayerInput lpInput;
    private Rigidbody rb;
    private string displayName;

    [Header("Movement")]
    public float speed;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckMask;
    public float jumpForce;

    [Header("UI")]
    public Text nameTag;

    [Header("References")]
    public Camera playerCamera;

    private void Awake()
    {
        lpInput = GetComponent<LocalPlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if(isLocalPlayer)
        {
            displayName = SteamFriends.GetFriendPersonaName(SteamUser.GetSteamID());
        }
    }

    private void Update()
    {
        playerCamera.gameObject.SetActive(isLocalPlayer);
        nameTag.text = displayName;
    }

    private void LateUpdate()
    {
        nameTag.transform.parent.LookAt(playerCamera.transform.position);
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            rb.transform.Translate((lpInput.moveInput * speed * Time.deltaTime), Space.Self);

            isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundCheckMask).Length > 0;
            if (isGrounded && lpInput.jumpInput)
            {
                rb.AddForce(jumpForce * Vector3.up, ForceMode.Acceleration);
            }
        }
    }
}
