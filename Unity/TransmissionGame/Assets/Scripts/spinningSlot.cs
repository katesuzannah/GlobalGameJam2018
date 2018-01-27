using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spinningSlot : MonoBehaviour {
	public Text slotText1;//the actual yext
	public Text slotText2;
	public Text slotText3;
	public Text slotText4;
	public Text slotText5;
	public Text slotText6;

	public Image[] slot;//the image inside the canvas that simulates spinning
	public Sprite originalSlot;//non-spinning slot chamber
	public Sprite[] slot1Blur;//spinning slot chamber
	public Image handle;//slot machine handle canvas image
	public Sprite handleUp;//slot machine sprite in neutral 
	public Sprite handleDown;//slot machine sprite pushed down

	int randomSlot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			slotText1.text = "";
			slotText2.text = "";
			slotText3.text = "";
			slotText4.text = "";
			slotText5.text = "";
			slotText6.text = "";

			randomSlot = Random.Range (0, 3);
			Debug.Log (randomSlot);
			slot[0].sprite = slot1Blur[randomSlot];
			slot [1].sprite = slot1Blur[randomSlot];
			slot[2].sprite = slot1Blur[randomSlot];
			slot [3].sprite = slot1Blur[randomSlot];
			slot[4].sprite = slot1Blur[randomSlot];
			slot [5].sprite = slot1Blur[randomSlot];

			//handle.transform.position = new Vector2 (handle.transform.position.x, -1);
			handle.sprite = handleDown;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			slotText1.text = "You";
			slotText2.text = "never";
			slotText3.text = "digested";
			slotText4.text = "my";
			slotText5.text = "ass";
			slotText6.text = "?";

			slot [0].sprite = originalSlot;
			slot [1].sprite = originalSlot;
			slot [2].sprite = originalSlot;
			slot [3].sprite = originalSlot;
			slot [4].sprite = originalSlot;
			slot [5].sprite = originalSlot;

			handle.sprite = handleUp;
		}
	}
}
