// David Zhang
// 997480088
// zyq.david@gmail.com
// ezdz.io
// 78 Holmes Drive, Toronto, Ontario
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class satellite : MonoBehaviour {
	public float KM_per_second;
	private float period;

	// orbiting height plus earth
	private float radius;
	
	private const float radius_earth = 6.371f;

	public float orbiting_height;

	public bool x_axis_rotate;	
	public bool y_axis_rotate;
	public bool z_axis_rotate;

	public bool targetCam;

	GameObject OVR;
	GameObject Earth;
	// Use this for initialization
	void Start () {
		if (targetCam) {
			OVR = GameObject.Find ("OVRPlayerController");
		}
		Earth = GameObject.Find("Earth");
		radius = radius_earth + orbiting_height;
		period = KMtoPeriod (KM_per_second);
	}

	private float KMtoPeriod (float speedInKM) {
		float orbit_circumference = 2 * Mathf.PI * radius;
		return orbit_circumference / speedInKM;
	}

	private float PeriodtoKM (float period) {
		float orbit_circumference = 2 * Mathf.PI * radius;
		return orbit_circumference/period;
	}
	
	// Update is called once per frame
	void Update () {

		float theta = ((Time.time % period) / period) * 360;
		theta *= (Mathf.PI / 180);
		Vector3 newPos = new Vector3(0,0,0);
		Vector3 newRot = new Vector3(0,0,0);
		
		/* Rotation about the X-Axis */
		/* (x,y,z) = (0,cos(theta),sin(theta)) */
		if (x_axis_rotate) {
			newPos = new Vector3 (0,
			                      (Mathf.Cos(theta)) * radius, 
			                      (Mathf.Sin(theta)) * radius) ;
			
			newRot = new Vector3 (0,
			                      -(Mathf.Cos(theta) * radius), 
			                      -(Mathf.Sin(theta) * radius)) ;
		}
		/* Rotation about the Y-Axis */
		/* (x,y,z) = (cos(theta),0,sin(theta)) */
		else if (y_axis_rotate) {
			newPos = new Vector3 ((Mathf.Cos(theta)) * radius, 
			                      0,
			                      (Mathf.Sin(theta)) * radius) ;
			newRot = new Vector3 (-(Mathf.Cos(theta) * radius), 
			                      0,
			                      -(Mathf.Sin(theta) * radius)) ;
		}
		/* Rotation about the Z-Axis */
		/* (x,y,z) = (cos(theta),sin(theta),0) */
		else if(z_axis_rotate) {
			newPos = new Vector3 ((Mathf.Cos(theta)) * radius, 
			                      (Mathf.Sin(theta)) * radius,
			                      0) ;
			newRot = new Vector3 (-(Mathf.Cos(theta) * radius), 
			                      -(Mathf.Sin(theta) * radius),
			                      0) ;
		}
		gameObject.transform.position = newPos;
		if (targetCam) {
			OVR.transform.position = newPos;
		}
//		OVR.transform.rotation.SetLookRotation (newRot);
	}
}
