using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinklingLights : MonoBehaviour {

	public Material originalMat;
	public Material newMat;
	Renderer[] rends;
	bool changeFlag;

	public float timer;

	void Start () {
		timer = Random.Range(3f, 5f);
		rends = GetComponentsInChildren<Renderer> ();
		changeFlag = true;
	}

	void Update () {
		timer -= Time.deltaTime;
		if (timer<0f) {
			if (changeFlag) {
				foreach(Renderer r in rends) {
					r.material = newMat;
					changeFlag = false;
				}
			}
			else {
				foreach(Renderer r in rends) {
					r.material = originalMat;
					changeFlag = true;
				}
			}
			timer = Random.Range(3f, 5f);
		}
	}
}