using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[DisallowMultipleComponent]
[AddComponentMenu("Network/CustomNetworkTransform")]
[HelpURL("https://mirror-networking.com/docs/Articles/Components/NetworkTransform.html")]
public class CustomNetworkTransform : CustomNetworkTransformBase
{
    public RigidbodyInterpolation rigidbodyInterpolation = RigidbodyInterpolation.Interpolate;
    protected override Transform targetComponent => transform;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.interpolation = rigidbodyInterpolation;
        }
    }
}
