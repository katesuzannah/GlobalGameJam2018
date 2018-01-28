using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinOneSlot : MonoBehaviour {

	private Image slot;
	private Sprite original;
	public Text slotText;
	bool spinning;
	public int me;
//	public ChooseRandomWord chooser;

	int randomSlot;
	public Sprite [] slotBlur;

	void Start () {
		slot = GetComponent<Image> ();
		original = slot.sprite;
	}

	void Update () {
//		if (Input.GetKeyDown(KeyCode.Space)) {
//			StartSpinning()
//		}
		if (spinning) {
			randomSlot = Random.Range (0, 3);
			slot.sprite = slotBlur [randomSlot];
			//Debug.Log (me + " is spinning");
		}
		else {
			slot.sprite = original;
		}
//		if (ChooseRandomWord.wordCounter == me && chooser.sentToSlotScript) {
//			slotText.text = chooser.wordChoice;
//			chooser.sentToSlotScript = false;
//			spinning = false;
//		}
	}

	public void StartSpinning () {
		spinning = true;
	}

	public void StopSpinning () {
		spinning = false;
	}
}