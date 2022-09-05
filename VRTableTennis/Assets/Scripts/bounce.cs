using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    public float minVelocity;
    Vector3 lastFrameVelocity;

    
    private void OnCollisionEnter(Collision collision)
    {
        lastFrameVelocity = GetComponent<Rigidbody>().velocity;
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collision.contacts[0].normal);
        GetComponent<Rigidbody>().velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
