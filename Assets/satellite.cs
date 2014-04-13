// David Zhang
// 997480088
// zyq.david@gmail.com
// ezdz.io
// 78 Holmes Drive, Toronto, Ontario
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class satellite : MonoBehaviour {
	public float period;
	public float radius;
	
	public bool x_axis_rotate;	
	public bool y_axis_rotate;
	public bool z_axis_rotate;
	
	GameObject OVR;
	
	
	// Use this for initialization
	void Start () {
		OVR = GameObject.Find("OVRPlayerController");
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
		
		OVR.transform.position = newPos;
//		OVR.transform.rotation.SetLookRotation (newRot);
	}
}
