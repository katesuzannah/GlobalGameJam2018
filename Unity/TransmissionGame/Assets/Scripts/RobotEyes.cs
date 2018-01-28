using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEyes : MonoBehaviour {

	public Material normal;
	public Material flash;
	Renderer myMaterial;
	bool lit;
	//public bool flashing;

	void Start () {
		lit = false;
		myMaterial = GetComponent<Renderer> ();
	}
//
//	void Update () {
//		if (Input.GetKeyDown(KeyCode.W)) {
//			FlashEyes ();
//		}
//	}

	public void FlashEyes () {
		if (!lit) {
			myMaterial.material = flash;
			lit = true;
		}
		else {
			myMaterial.material = normal;
			lit = false;
		}
	}
}