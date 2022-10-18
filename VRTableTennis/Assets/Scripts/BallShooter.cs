using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BallShooter : MonoBehaviour
{
   [SerializeField] GameObject BallSpawnPoint;
   [SerializeField] GameObject ShootBall;

	Controls controls;
    [SerializeField] bool button;

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
        if (button == true && EventSystem.current.IsPointerOverGameObject())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        
   }


    private void shootBall()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Hovering");
        }

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


