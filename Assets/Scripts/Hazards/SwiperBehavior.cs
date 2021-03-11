using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SwiperBehavior : NetworkBehaviour
{
    public float speedMultiplier;
    public Vector3 torque;

    private Rigidbody rb;

    private void Start()
    {
        if (!isServer) Destroy(this); //server only
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }

    private void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, rb.rotation * Quaternion.Euler(torque), Time.fixedDeltaTime * speedMultiplier));
    }
}
