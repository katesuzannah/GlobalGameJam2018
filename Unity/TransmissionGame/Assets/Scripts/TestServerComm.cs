using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestServerComm : MonoBehaviour {

	ServerComm serv;

	// Use this for initialization
	void Start () {
		serv = GetComponent<ServerComm>();
	}

	void UseResults(string[] results) {
		Debug.Log("got results:");
		foreach (string s in results) {
			Debug.Log(s);
		}
	}

	void UsePlayerCount(string count) {
		Debug.Log("players: " + count);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			serv.GetResults(gameObject, "UseResults");
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			serv.StartRound(gameObject, "UsePlayerCount");
		}
	}
}
