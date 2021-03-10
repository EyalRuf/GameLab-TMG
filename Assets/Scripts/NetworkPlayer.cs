using UnityEngine;
using System.Collections;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public LocalPlayerInput lpInput;
    public ThirdPersonCharacterController characterController;

    public override void OnStartLocalPlayer()
    {
        playerCamera.gameObject.SetActive(true);
        lpInput.enabled = true;
        characterController.enabled = true;
    }
}
