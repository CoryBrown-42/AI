using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringAgent : MonoBehaviour {

	public float Mass = 10;
	public float maxVelocity = 1;
	public float Friction = 0.01f;

	public bool rotateSprite = false;

	public Transform TargetPoint;

	Vector2 CurrentVelocity;


	void Start () 
	{
		
	}
	

	void FixedUpdate () 
	{
		Vector2 acceloration = Vector2.zero;
		// Compute the right acceleration

		acceloration += (((Vector2)TargetPoint.position - (Vector2)transform.position).normalized * maxVelocity) - CurrentVelocity;

		CurrentVelocity += acceloration / Mass;
		CurrentVelocity -= CurrentVelocity / Friction;

		if(CurrentVelocity.magnitude > maxVelocity)
		{
			CurrentVelocity = CurrentVelocity.normalized * maxVelocity;
		}
		transform.position = transform.position + (Vector3)CurrentVelocity * Time.fixedDeltaTime;
	}
}
