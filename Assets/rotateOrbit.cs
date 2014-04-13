using UnityEngine;
using System.Collections;

public class rotateOrbit : MonoBehaviour {

	//toggle rotation about one axis
	public bool singleAxisRotation;
	public float rotateOrbitSpeed;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!singleAxisRotation) 
			gameObject.transform.Rotate (rotateOrbitSpeed, 0, 0);
	}
}
