using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleAnimation : MonoBehaviour {
	public Image handle;//slot machine handle canvas image
	public Sprite handleUp;//slot machine sprite in neutral 
	public Sprite handleDown;//slot machine sprite pushed down
	Vector2 handleUpPos;

	void Start () {
		handleUpPos = handle.transform.localPosition;
	}

	public void PullHandle () {
		handle.sprite = handleDown;
		handle.transform.localPosition = new Vector2 (handle.transform.localPosition.x, handle.transform.localPosition.y - 55f);
	}

	public void ReleaseHandle () {
		handle.sprite = handleUp;
		handle.transform.localPosition = handleUpPos;
	}
}