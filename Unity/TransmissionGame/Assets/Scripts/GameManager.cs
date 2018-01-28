using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

//	public CameraController cam;
	public CameraControl cam;

	public ServerComm serv;

	public Canvas slotMachine;
	public ChooseRandomWord slotManager;
	public HandleAnimation lever;
	public VoiceRSSTextToSpeech TTS;
	public AudioSource Bot1Source;
	public AudioSource Bot2Source;

	AudioSource globalSfx;

	void Start() {
		EnterState(State.ZoomedOut);
		currTurn = Turn.Bot1;
		slotMachine.gameObject.SetActive(false);
	}

	void Update() {
		RunState(currState);
	}

	//Loop through:
	//1. romantic view of both robots
	//2. zoom into one robot
	//3. cut to slot machine view & start spinning
	//4. loop till end of sentence:
		//a. start round
		//b. wait x seconds
		//c. end round
		//d. choose random submitted word
		//e. display
	//5. once sentence complete, zoom out to main view and trigger TTS

	public enum State {
		ZoomedOut,
		ZoomedIn,
//		ShowSlotMachine,
		BuildingSentence,
		Speaking
	}

	public enum Turn {
		Bot1,
		Bot2
	}
	Turn currTurn;
	Turn CurrentTurn {
		get {
			return currTurn;
		}
	}

	State currState;
	State CurrentPhase {
		get {
			return currState;
		}
	}

	void EnterState(State state) {
		Debug.Log("Entering state " + state.ToString());
		ExitState(currState);
		currState = state;
		switch (state) {

		case State.ZoomedOut:
			EnterZoomedOut();
			break;
		case State.ZoomedIn:
			EnterZoomedIn();
			break;
//		case State.ShowSlotMachine:
//			EnterSlotMachine();
//			break;
		case State.BuildingSentence:
			EnterBuildingSentence();
			break;
		case State.Speaking:
			EnterSpeaking();
			break;
		}
	}

	//runs one frame of state
	void RunState(State state) {
		switch (state) {

		case State.ZoomedOut:
			RunZoomedOut();
			break;
		case State.ZoomedIn:
			RunZoomedIn();
			break;
//		case State.ShowSlotMachine:
//			RunSlotMachine();
//			break;
		case State.BuildingSentence:
			RunBuildingSentence();
			break;
		case State.Speaking:
			RunSpeaking();
			break;
		}
	}

	void ExitState(State state) {
		switch (state) {

		case State.ZoomedOut:
			ExitZoomedOut();
			break;
		case State.ZoomedIn:
			ExitZoomedIn();
			break;
//		case State.ShowSlotMachine:
//			ExitSlotMachine();
//			break;
		case State.BuildingSentence:
			ExitBuildingSentence();
			break;
		case State.Speaking:
			ExitSpeaking();
			break;
		}
	}

	//----------ZoomedOut------------//
	public float TimeBtwnSentences = 3f;
	float btwnSentencesTimer;

	void EnterZoomedOut() {
		cam.ZoomOut();
		btwnSentencesTimer = TimeBtwnSentences;
	}

	void RunZoomedOut() {
		btwnSentencesTimer -= Time.deltaTime;
		if (btwnSentencesTimer <= 0f) {
			EnterState(State.ZoomedIn);
		}
	}

	void ExitZoomedOut() {
		//do nothing
	}

	//----------ZoomedIn------------//
	public float TimeZoomedIn = 2f;
	float zoomedInTimer;

	void EnterZoomedIn() {
		zoomedInTimer = TimeZoomedIn;
		//switch turn to new bot and zoom
		switch (currTurn) {
		case Turn.Bot1:
			currTurn = Turn.Bot2;
			cam.ZoomInBot2();
			break;
		case Turn.Bot2:
			currTurn = Turn.Bot1;
			cam.ZoomInBot1();
			break;
		}
	}

	void RunZoomedIn() {
		zoomedInTimer -= Time.deltaTime;
		if (zoomedInTimer <= 0f) {
//			EnterState(State.ShowSlotMachine);
			EnterState(State.BuildingSentence);
		}
	}

	void ExitZoomedIn() {
		//do nothing
	}

	//----------SlotMachine------------//



//	void EnterSlotMachine() {
//		slotMachine.gameObject.SetActive(true);
//	}
//
//	void RunSlotMachine() {
//
//	}
//
//	void ExitSlotMachine() {
//		slotMachine.gameObject.SetActive(false);
//	}

	//----------BuildingSentence------------//

	//structure here:
		//a. start round
		//b. wait x seconds
		//c. end round
		//d. choose random submitted word
		//e. display

	/*
	 * anim slots:
	 * SpinOneSlot is on each slot
	 * 		StartSpinning --starts it spinning
	 * 		StopSpinning --stops it
	 * handleAnimation:
	 * 		PullHandle: moves handle down
	 * 		ReleaseHandle: moves it up
	 */

	string sentence;
	public int wordsPerSentence = 5;
	int roundNum;
	public int RoundNum {
		get {
			return roundNum;
		}
	}
	public float TimePerRound = 15f;
	float roundTimer;
	bool roundRunning;

	void StartRound() {
		roundRunning = true;
		roundTimer = 0f;
		serv.StartRound(gameObject, "GetRoundStartInfo");
	}

	void EndRound() {
		roundRunning = false;
		serv.GetResults(gameObject, "GetRoundEndInfo");
	}

	public int GetRoundStartInfo() {
		//TODO: display players connected
		return 0;
	}

	public void GetRoundEndInfo(string[] results) {
//		int rng = Random.Range(0, results.Length);
//		sentence += results[rng]+ " ";
//		//TODO: display word chosen
//		roundNum++;
		sentence += slotManager.ChooseWord(results, roundNum) + " ";
		roundNum++;
		if (roundNum < wordsPerSentence) {
			StartRound();
		}
		else {
			EnterState(State.Speaking);
		}
	} 

	IEnumerator WaitForHandle(float seconds) {
		yield return new WaitForSeconds(seconds);
		lever.PullHandle();
		slotManager.Spin();
		yield return new WaitForSeconds(seconds);
		lever.ReleaseHandle();
	}

	void EnterBuildingSentence() {
		sentence = "";
		roundNum = 0;
		roundTimer = 0f;
		slotMachine.gameObject.SetActive(true);
		slotManager.Reset();
//		lever.PullHandle();
		StartCoroutine(WaitForHandle(.5f));
		StartRound();
	}

	void RunBuildingSentence() {
		if (roundRunning) {
			roundTimer += Time.deltaTime;
			if (roundTimer >= TimePerRound) {
				EndRound();
			}
		}
	}

	void ExitBuildingSentence() {
//		slotMachine.gameObject.SetActive(false);
	}

	//----------Speaking------------//
	void StartSpeech() {
		Debug.Log("Before clip sent");
		Debug.Log("sentence: " + sentence);
		TTS.GetClip(gameObject, sentence, "Speak");
	}

	public void Speak(AudioClip clip) {
		Debug.Log("Got clip from server");
		StartCoroutine(WaitForSpeech(clip));
	}

	IEnumerator WaitForSpeech(AudioClip clip) {
		switch (currTurn) {
		case Turn.Bot1:
			Bot1Source.PlayOneShot(clip);
			break;
		case Turn.Bot2:
			Bot2Source.PlayOneShot(clip);
			break;
		}
		yield return new WaitForSeconds(clip.length);
		Debug.Log("clip finished playing");
		EnterState(State.ZoomedOut);
	}


	void EnterSpeaking() {
		//TODO: disable slot view
		//TODO: trigger speech animation
		StartSpeech();
	}

	void RunSpeaking() {
		//handled by WaitForSpeech
	}

	void ExitSpeaking() {
		//do nothing
		slotMachine.gameObject.SetActive(false);
	}
}
