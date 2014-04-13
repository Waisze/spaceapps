using UnityEngine;
using System.Collections;

public class earthrotate : MonoBehaviour {
	public float rotate_speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(0, rotate_speed, 0);
	}
}
