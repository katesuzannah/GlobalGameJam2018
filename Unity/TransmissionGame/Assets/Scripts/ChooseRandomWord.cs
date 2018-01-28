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
	public VoiceRSSTextToSpeech TTS;
	string finalSentence;

	void Start () {
//		source = GetComponent<AudioSource> ();
		sentToSlotScript = false;
		wordCounter = 0;
		foreach(Text t in wordDisplays) {
			t.text = "";
		}
		finalSentence = "";
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			ChooseWord ();
		}
	}

	void ChooseWord () {
		allWords = serverCommunicator.GetResults ();
		wordChoice = allWords [Random.Range (0, allWords.Length)];
//		Debug.Log (wordChoice);
		wordDisplays [wordCounter].text = wordChoice;
//		sentToSlotScript = true;
		slotScripts[wordCounter].StopSpinning();
		wordCounter++;
		finalSentence += wordChoice + " ";
		Debug.Log (wordCounter);
		if (wordCounter>=wordDisplays.Length) {
			SayWords (finalSentence);
			Debug.Log ("HDFSLKHGDS");
		}
	}

	void SayWords (string sentence) {
		TTS.GetClip(gameObject, sentence, "SaySentence");
	}

	public void SaySentence(AudioClip clip) {
		TTS.GetComponent<AudioSource>().PlayOneShot (clip);
		Debug.Log ("SaySentence");
	}
}