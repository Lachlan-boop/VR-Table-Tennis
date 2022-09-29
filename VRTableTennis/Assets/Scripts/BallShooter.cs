using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] GameObject BallSpawnPoint;
   [SerializeField] GameObject ShootBall;

   private void Update()
   {
		if(Input.GetButtonDown("Fire!"))
		{
			Instantiate(ShootBall, BallSpawnPoint.transform.position, BallSpawnPoint,transform.rotation);
		}
   }
}
