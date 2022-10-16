using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
   [SerializeField] GameObject BallSpawnPoint;
   [SerializeField] GameObject ShootBall;

	Controls controls;

    [SerializeField] float BallforceUp = 5;
    [SerializeField] float BallForceForward = 50;
    GameObject ball;

    private void Start()
    {
        controls.PlayerInput.PickupBall.started += ctx => shootBall();
        ball = Instantiate(ShootBall, BallSpawnPoint.transform.position, transform.rotation);
    }

	private void Update()
   {

   }


    private void shootBall()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        ball.transform.position = BallSpawnPoint.transform.position;
        rb.velocity = Vector3.zero;
        rb.AddForce((transform.forward * BallForceForward  + transform.up * BallforceUp), ForceMode.Impulse);
        print("dropped");
    }


    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
        }
        controls.PlayerInput.Enable();
    }

}


