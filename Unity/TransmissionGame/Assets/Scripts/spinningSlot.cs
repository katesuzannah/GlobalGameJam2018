using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spinningSlot : MonoBehaviour {
	/*
	public Text slotText1;//the actual yext
	public Text slotText2;
	public Text slotText3;
	public Text slotText4;
	public Text slotText5;
	public Text slotText6;

	public Image[] slot;//the image inside the canvas that simulates spinning
	public Sprite originalSlot;//non-spinning slot chamber
	public Sprite[] slot1Blur;//spinning slot chamber
	*/
	public Image handle;//slot machine handle canvas image
	public Sprite handleUp;//slot machine sprite in neutral 
	public Sprite handleDown;//slot machine sprite pushed down
	Vector2 handleUpPos;

	/*
	bool isSpinning;
	bool is1Spinning;
	bool is2Spinning;
	bool is3Spinning;
	bool is4Spinning;
	bool is5Spinning;
	int randomSlot;

	int spinTimer=300;
	// Use this for initialization
	*/
	void Start () {
		handleUpPos = handle.transform.localPosition;
	}

	void Update () {
//		Debug.Log (spinTimer);
		if (Input.GetKeyDown (KeyCode.Space)) {
			//handle.transform.position = new Vector2 (handle.transform.position.x, handle.transform.position.y-10);
			handle.sprite = handleDown;
			handle.transform.localPosition = new Vector2 (handle.transform.localPosition.x, handle.transform.localPosition.y - 55f);
		}
			/*
			spinTimer = 300;
			isSpinning = true;
			is1Spinning = true;
			is2Spinning = true;
			is3Spinning = true;
			is4Spinning = true;
			is5Spinning = true;
		}

		if (isSpinning == true) {
			spinTimer--;
//			slotText1.text = "";
//			slotText2.text = "";
//			slotText3.text = "";
//			slotText4.text = "";
//			slotText5.text = "";
//			slotText6.text = "";

			randomSlot = Random.Range (0, 3);
			Debug.Log (randomSlot);

			slot [0].sprite = slot1Blur [randomSlot];
			slot [1].sprite = slot1Blur [randomSlot];
			slot [2].sprite = slot1Blur [randomSlot];
			slot [3].sprite = slot1Blur [randomSlot];
			slot [4].sprite = slot1Blur [randomSlot];
			slot [5].sprite = slot1Blur [randomSlot];

		} 
		if(isSpinning==false) {
//			slotText1.text = "You";
//			slotText2.text = "never";
//			slotText3.text = "digested";
//			slotText4.text = "my";
//			slotText5.text = "ass";
//			slotText6.text = "?";

			slot [0].sprite = originalSlot;
			slot [1].sprite = originalSlot;
			slot [2].sprite = originalSlot;
			slot [3].sprite = originalSlot;
			slot [4].sprite = originalSlot;
			slot [5].sprite = originalSlot;
		}

		if (spinTimer==0) {
			isSpinning = false;
		}
		*/
		if (Input.GetKeyUp (KeyCode.Space)) {
			handle.sprite = handleUp;
			handle.transform.localPosition = handleUpPos;
		}
	}
}
