using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bounce : MonoBehaviour
{

    [SerializeField] float Force = 50f;
    Rigidbody rb;

    public float minVelocity;
    Vector3 lastFrameVelocity;
    public Transform Hand;

    bool isAttached = false;

    Controls controls;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * Force, ForceMode.Impulse);


        controls.PlayerInput.PickupBall.started += ctx => pickupBall();
        controls.PlayerInput.PickupBall.canceled += ctx => DropBall();
    }

    private void Update()
    {//Axis1D.PrimaryIndexTrigger 
        if(isAttached)
        {
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = Hand.transform.position;
        } else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }

    }

    private void OnEnable()
    {
        if(controls == null)
        {
            controls = new Controls();
        }
        controls.PlayerInput.Enable();
    }

    private void pickupBall()
    {
        //isAttached = true;
        //transform.position = Hand.transform.position;
    }

    private void DropBall()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        isAttached = false;
        print("dropped");   
    }

    private void OnCollisionEnter(Collision collision)
    {
        //lastFrameVelocity = GetComponent<Rigidbody>().velocity;
        //var speed = lastFrameVelocity.magnitude;
        //var direction = Vector3.Reflect(lastFrameVelocity.normalized, collision.contacts[0].normal);
        //GetComponent<Rigidbody>().velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
