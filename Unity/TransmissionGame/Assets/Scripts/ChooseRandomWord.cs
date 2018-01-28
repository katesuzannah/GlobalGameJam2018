using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRandomWord : MonoBehaviour {

	public string wordChoice;
	//string[] allWords;
//	public ServerComm serverCommunicator;
	public Text[] wordDisplays;
//	public static int wordCounter;
	public bool sentToSlotScript;
	public SpinOneSlot[] slotScripts;
//	public VoiceRSSTextToSpeech TTS;
//	string finalSentence;

	public void Spin() {
		foreach (SpinOneSlot slot in slotScripts) {
			slot.StartSpinning();
		}
	}

	public void Reset () {
		//was Start()
//		source = GetComponent<AudioSource> ();
		sentToSlotScript = false;
//		wordCounter = 0;
		foreach(Text t in wordDisplays) {
			t.text = "";
		}
//		foreach (SpinOneSlot slot in slotScripts) {
//			slot.StartSpinning();
//		}
//		finalSentence = "";
	}

	void Update () {
//		if (Input.GetKeyDown(KeyCode.R)) {
//			ChooseWord ();
//		}
	}

//	void GetWords () {
//		serverCommunicator.GetResults (gameObject, "ChooseWord");
//	}
//
	public string ChooseWord (string[] words, int wordCounter) {
		//allWords = serverCommunicator.GetResults ();
		wordChoice = words [Random.Range (0, words.Length)];
//		Debug.Log (wordChoice);
		wordDisplays [wordCounter].text = wordChoice;
//		sentToSlotScript = true;
		slotScripts[wordCounter].StopSpinning();
		return wordChoice;
//		wordCounter++;
//		finalSentence += wordChoice + " ";
//		Debug.Log (wordCounter);
//		if (wordCounter>=wordDisplays.Length) {
//			SayWords (finalSentence);
//			Debug.Log ("HDFSLKHGDS");
//		}
	}
//
//	void SayWords (string sentence) {
//		TTS.GetClip(gameObject, sentence, "SaySentence");
//	}
//
//	public void SaySentence(AudioClip clip) {
//		TTS.GetComponent<AudioSource>().PlayOneShot (clip);
//		Debug.Log ("SaySentence");
//	}
}