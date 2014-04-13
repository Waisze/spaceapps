using UnityEngine;
using System.Collections;

public class rotateOrbit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (Time.deltaTime, 0, 0);
	}
}
