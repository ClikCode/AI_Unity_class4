﻿using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 0.5f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

		// TODO 3: Create a vector to calculate our ideal velocity
		// then calculate the acceleration needed to match that velocity
		// before sending it to move.AccelerateMovement() clamp it to 
		// move.max_mov_acceleration

		float distanceToTargetMagnitude = target.magnitude - move.transform.position.magnitude;

		Vector3 distanceToTarget = target - move.transform.position;
		distanceToTarget.Normalize();

		Debug.Log (slow_distance);
		if ((distanceToTargetMagnitude < slow_distance) && (distanceToTargetMagnitude > min_distance)) 
		{
			move.AccelerateMovement (-move.movement/min_distance);
		} 
		else if (distanceToTargetMagnitude < min_distance) 
		{

			move.AccelerateMovement (-move.movement);
		}




	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
