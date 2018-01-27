using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spinningSlot : MonoBehaviour {
	public Text slotText1;
	public Text slotText2;
	public Text slotText3;
	public Text slotText4;
	public Text slotText5;
	public Text slotText6;

	public Image[] slot;
	public Sprite slot1Blur;
	public Image handle;
	public Sprite handleDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			slotText1.text = "";
			slotText2.text = "";
			slotText3.text = "";
			slotText4.text = "";
			slotText5.text = "";
			slotText6.text = "";

			slot[0].sprite = slot1Blur;
			slot [1].sprite = slot1Blur;
			slot[2].sprite = slot1Blur;
			slot [3].sprite = slot1Blur;
			slot[4].sprite = slot1Blur;
			slot [5].sprite = slot1Blur;

			handle.transform.position = new Vector2 (handle.transform.position.x, -10);
			handle.sprite = handleDown;
		}
	}
}
