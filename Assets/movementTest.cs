using UnityEngine;
using System.Collections;

public class movementTest : MonoBehaviour {
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

	// Use this for initialization
	void Start () {
		initial_x = gameObject.transform.position.x;
		initial_y = gameObject.transform.position.y;
		initial_z = gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.time;
		//x axis rotation
		/*if (x_axis_rotate) {
			gameObject.transform.position = new Vector3 (initial_x,
			                                             (Mathf.Sin(time * speed)) * radius_y + initial_y, 
			                                             (Mathf.Cos(time * speed)) * radius_z + initial_z );	
		}
		//y axis rotation
		else if (y_axis_rotate) {*/
			gameObject.transform.position = new Vector3 ((Mathf.Sin(time * speed)) * radius_x + initial_x,
			                                             (Mathf.Sin(time * speed)) * radius_y + initial_y, 
			                                             (Mathf.Cos(time * speed)) * radius_z + initial_z );
		/*}
		//z axis rotation
		else if(z_axis_rotate) {
			gameObject.transform.position = new Vector3 ((Mathf.Sin(time * speed)) * radius_x + initial_x,
			                                             (Mathf.Cos(time * speed)) * radius_y + initial_y, 
			                                             initial_z);	
		}
		else {
			Debug.Log("Need to specify an axis of rotation");
		}*/
	}
}
