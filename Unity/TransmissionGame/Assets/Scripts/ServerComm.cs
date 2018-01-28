using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerComm : MonoBehaviour {

	public string testSentence = "You never digested my ass?";

	/* 
	 * End the round on the server
	 * Receive submitted words as JSON
	 * Parse and return as string array
	 */
	public string[] GetResults() {
		return testSentence.Split();
	}


	/*
	 * send round game data as JSON to server (if any is necessary for our design)
	 * Start round on server
	 * receive player info as JSON
	 * return number of players connected
	 */
	public int StartRound(string gameData) {
		return Random.Range(1, 20);
	}

}
