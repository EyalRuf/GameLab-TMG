using UnityEngine;
using System.Collections;
using Mirror;
using Steamworks;
using UnityEngine.UI;

public class NetworkPlayer : NetworkBehaviour
{
    [Header("Network")]
    public bool isConnectedThroughSteam;

    [Header("References")]
    public Camera playerCamera;
    public LocalPlayerInput lpInput;
    public ThirdPersonCharacterController characterController;

    [Header("UI")]
    public Text nameTag;

    public override void OnStartLocalPlayer()
    {
        playerCamera.gameObject.SetActive(true);
        lpInput.enabled = true;
        characterController.enabled = true;

        if (isConnectedThroughSteam)
        {
            nameTag.text = SteamFriends.GetFriendPersonaName(SteamUser.GetSteamID());
        }
    }

    private void LateUpdate()
    {
        nameTag.transform.parent.LookAt(playerCamera.transform.position);
    }
}
