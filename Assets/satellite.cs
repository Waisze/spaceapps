﻿// David Zhang
// 997480088
// zyq.david@gmail.com
// ezdz.io
// 78 Holmes Drive, Toronto, Ontario
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class satellite : MonoBehaviour {
	// speed in mega meters per second 
	public float Mm_per_second;
	// orbiting height in Mm
	public float height_in_Mm;
	// theta_in_sec
	public float alt_in_sec = 120;
	// theta deg
	public float init_theta;
	// targetCam boolean
	public bool targetCam;

	// orbiting height plus earth
	private float radius_in_Mm;
	// period in seconds
	private float period_in_sec;
	// radius of earth in Mm
	private const float radius_earth = 6.371f;
	// inkeeper for our phi
	private float phi;

	GameObject OVR;
	GameObject Earth;
	// Use this for initialization
	void Start () {
		if (targetCam) {
			OVR = GameObject.Find ("OVRPlayerController");
		}
		Earth = GameObject.Find("Earth");
		radius_in_Mm = height_in_Mm + radius_earth;
		period_in_sec = MMtoPeriod(Mm_per_second);
	}

	private float MMtoPeriod (float speedInMM) {
		float orbit_circumference = 2 * Mathf.PI * radius_in_Mm;
		return orbit_circumference / speedInMM;
	}

	private float PeriodtoMM (float periodInSec) {
		float orbit_circumference = 2 * Mathf.PI * radius_in_Mm;
		return orbit_circumference / periodInSec;
	}
	
	// Update is called once per frame
	void Update () {
		// calculate dphi
		//float dtheta = (2 * Mathf.PI / period_in_sec);
		float dphi = (2 * Mathf.PI / period_in_sec);

		// calculate the new theta and new phi
		phi += dphi;

		Vector3 newPos = new Vector3(0,0,0);
		Vector3 newRot = new Vector3(0,0,0);

		// create vector in sphereical coordinates
		newPos = new Vector3 (radius_in_Mm * Mathf.Cos (init_theta) * Mathf.Sin (phi),
		                      radius_in_Mm * Mathf.Sin (init_theta) * Mathf.Sin (phi),
		                      radius_in_Mm * Mathf.Cos (phi));

		gameObject.transform.localPosition = newPos;

		if (targetCam) {
			OVR.transform.position = newPos;
		}

		/* Game pad controls */
		if (Input.GetKey("up")) {
			period_in_sec+=1;
			Mm_per_second = PeriodtoMM(period_in_sec);
		}
		if (Input.GetKey("down")) {
			period_in_sec-=1;
			Mm_per_second = PeriodtoMM(period_in_sec);
		}
	}
}
