﻿using UnityEngine;
using System.Collections;
using Magicolo;

public class RunnerCamera : MonoBehaviour {

	public float translateSpeed = 5;
	public float rotateSpeed = 5;
	public float pressureSpeed = 10;
	public float pressureThreshold = 0.9F;
	public float recoverSpeed = 2;
	public float killDistance = 10;
	public Vector3 offset = new Vector3(0, 0, -50);
	public Vector3 lastPosition;
	
	void FixedUpdate() {
		transform.RotateTowards(References.Runner.orientation, 5, "Z");
		
		float distance = Vector3.Distance(lastPosition, References.Runner.transform.position);
		transform.TranslateTowards(References.Runner.transform.localPosition + offset.Rotate(-transform.eulerAngles.z), translateSpeed);
		killIfTooFar(distance);
		if (distance > pressureThreshold && offset.x > 0) {
			offset.x -= Time.fixedDeltaTime * recoverSpeed;
		}
		else {
			offset.x += Time.fixedDeltaTime * pressureSpeed;
		}
		
		lastPosition = References.Runner.transform.position;
	}

	void killIfTooFar(float distance){
		if(distance > killDistance){
			References.Runner.die();
		}
	}
}
