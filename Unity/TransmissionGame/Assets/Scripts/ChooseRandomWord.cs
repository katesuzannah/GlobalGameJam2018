using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRandomWord : MonoBehaviour {

	public string wordChoice;
	string[] allWords;
	public ServerComm serverCommunicator;
	public Text[] wordDisplays;
	public static int wordCounter;
	public bool sentToSlotScript;
	public SpinOneSlot[] slotScripts;

	void Start () {
		sentToSlotScript = false;
		wordCounter = 0;
		foreach(Text t in wordDisplays) {
			t.text = "";
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			ChooseWord ();
		}
	}

	void ChooseWord() {
		allWords = serverCommunicator.GetResults ();
		wordChoice = allWords [Random.Range (0, allWords.Length)];
//		Debug.Log (wordChoice);
		wordDisplays [wordCounter].text = wordChoice;
//		sentToSlotScript = true;
		slotScripts[wordCounter].StopSpinning();
		wordCounter++;

		if (wordCounter>wordDisplays.Length) {
			//Sentence is over
		}
	}
}
