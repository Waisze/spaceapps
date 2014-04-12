using UnityEngine;
using System.Collections;

public class rockbird : MonoBehaviour {


	public int counter;
	// Use this for initialization
	void Start () {
		counter = 0;
			
	}
	
	// Update is called once per frame
	void Update () {
		if ((counter % 60) == 0) {
			//gameObject.AddForce = new Vector3 (0, -10f, 0);
			counter = 0;
		}
		counter++;
	}
}
