using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasDisappear : MonoBehaviour {
	public GameObject canvasObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Disappear(){
		canvasObject.SetActive(false);
	}
	public void Reappear(){
		canvasObject.SetActive (true);
	}
}
