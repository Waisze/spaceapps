using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class satillite : MonoBehaviour {
	public float time;
	public float speed;

	public float radius_x;
	public float radius_y;
	public float radius_z;
	
	public bool x_axis_rotate;	
	public bool y_axis_rotate;
	public bool z_axis_rotate;

	public float initial_x;
	public float initial_y;
	public float initial_z;
	GameObject OVR;


	// Use this for initialization
	void Start () {
		initial_x = gameObject.transform.position.x;
		initial_y = gameObject.transform.position.y;
		initial_z = gameObject.transform.position.z;

		OVR = GameObject.Find("OVRPlayerController");

	}
	
	// Update is called once per frame
	void Update () {
		time = Time.time;
		Vector3 newPos = new Vector3(0,0,0);
		//x axis rotation
		if (x_axis_rotate) {
			newPos = new Vector3 (	((Mathf.Sin(time * speed *10)) * radius_x)/3,
			                  		(Mathf.Sin(time * speed)) * radius_y + initial_y, 
			               			(Mathf.Cos(time * speed)) * radius_z + initial_z );
		}
		//y axis rotation
		else if (y_axis_rotate) {
			newPos = new Vector3 ((	Mathf.Sin(time * speed)) * radius_x + initial_x,
		              				((Mathf.Sin(time * speed *10)) * radius_y)/3,
		                    		(Mathf.Cos(time * speed)) * radius_z + initial_z );
		}
		//z axis rotation
		else if(z_axis_rotate) {
			newPos = new Vector3 ((	Mathf.Sin(time * speed)) * radius_x + initial_x,
			                 		(Mathf.Cos(time * speed)) * radius_y + initial_y, 
			                      	((Mathf.Sin(time * speed *10)) * radius_z)/3 );
		}
		gameObject.transform.position = newPos;
		OVR.transform.position = newPos;
	}
}
