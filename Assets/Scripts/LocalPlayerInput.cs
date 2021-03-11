using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerInput : MonoBehaviour
{
    public Vector3 moveInput = Vector3.zero;
    public bool jumpInput = false;
    public bool jumpInputDown = false;

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        if (Mathf.Abs(ver) < 0.01f)
            ver = 0;
        if (Mathf.Abs(hor) < 0.01f)
            hor = 0;

        moveInput = new Vector3(hor, 0, ver);
        jumpInput = Input.GetKey(KeyCode.Space);
        jumpInputDown = Input.GetKeyDown(KeyCode.Space);
    }
}
