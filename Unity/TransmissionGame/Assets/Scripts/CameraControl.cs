using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this script on the camera
public class CameraControl : MonoBehaviour {

	Vector3 startPos;
	Vector3 startRot;
	Quaternion startQuat;
	Vector3 newPos;
	Vector3 newRot;
	public Transform left;
	public Transform right;
	//Transform center;
	Transform target;

	float speed =5f;
	float startTime;
	float journeyLength;
	float distCovered;
	float fracJourney;

	public bool zoomingIn;
	public bool zoomingOut;
	public float rotSpeed;

	void Start () {
		startPos = transform.position; //(0f, 1.261f, -9.377f)
		startQuat = transform.rotation;
		zoomingIn = false;
		zoomingOut = false;
	}

	void Update () {
		/*
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			ZoomIn (0);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			ZoomIn (1);
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			ZoomOut ();
		}
		*/
		if (zoomingIn) {
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (transform.position, newPos, fracJourney);
			transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, Time.time * rotSpeed);
			if (Vector3.Distance (transform.position, newPos) < .001f && (Quaternion.Angle(transform.rotation, target.rotation) < .001f)) {
				zoomingIn = false;
			}
		}
		else if (zoomingOut) {
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (transform.position, startPos, fracJourney);
			transform.rotation = Quaternion.Lerp (transform.rotation, startQuat, Time.time * rotSpeed);
			if ((Vector3.Distance (transform.position, startPos) < .001f) && (Quaternion.Angle(transform.rotation, startQuat) < .001f)) {
				zoomingOut = false;
			}
		}
	}

	public void ZoomIn (int robot) {
		startTime = Time.time;
		if (robot==0) {
			newPos = new Vector3 (-0.054f, 1.213f, -9.2f);
			newRot = new Vector3 (13.488f, -29.822f, -2.225f);
			target = left;
		}
		else {
			newPos = new Vector3 (0.197f, 1.237f, -9.262f);
			newRot = new Vector3 (11.533f, 16.665f, 2.853f);
			target = right;
		}
		journeyLength = Vector3.Distance (startPos, newPos);
		zoomingIn = true;
	}

	public void ZoomOut () {
		startTime = Time.time;
		journeyLength = Vector3.Distance (newPos, startPos);
		zoomingOut = true;
	}
}