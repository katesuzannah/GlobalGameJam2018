using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEyes : MonoBehaviour {

	public Material normal;
	public Material flash;
	Renderer myMaterial;
	bool lit;
	float timer;
	public bool flashing;

	void Start () {
		lit = false;
		myMaterial = GetComponent<Renderer> ();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
			FlashEyes ();
		}
		if (flashing) {
			timer += Time.deltaTime;
			if (timer>.3f) {
				if (!lit) {
					myMaterial.material = flash;
					lit = true;
				}
				else {
					myMaterial.material = normal;
					lit = false;
				}
				timer = 0f;
			}
		}
		else {
			timer = 0f;
			myMaterial.material = normal;
		}
	}

	public void FlashEyes () {
		flashing = true;
	}

	public void StopFlashing () {
		flashing = false;
	}
}