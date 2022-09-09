using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bounce : MonoBehaviour
{
    public float minVelocity;
    Vector3 lastFrameVelocity;

    public InputActionMap actionMap;
    public InputAction pickupAction;

    private void Start()
    {
        pickupAction.started += ctx => pickupBall();
        pickupAction.canceled += ctx => DropBall();
    }

    private void Update()
    {//Axis1D.PrimaryIndexTrigger   

    }

    private void OnEnable()
    {
        pickupAction = actionMap.FindAction("PickupBall");
        pickupAction.Enable();

    }

    private void pickupBall()
    {
        print("PICKUP");
    }

    private void DropBall()
    {
        print("drop");
    }

    private void OnCollisionEnter(Collision collision)
    {
        lastFrameVelocity = GetComponent<Rigidbody>().velocity;
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collision.contacts[0].normal);
        GetComponent<Rigidbody>().velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
