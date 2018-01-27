using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InterfaceWithServer : MonoBehaviour {

	public float timer;
	public string[] partsOfSpeech;

	void Start () {
		StartCoroutine (GetWords ());
	}
		
	IEnumerator GetWords() {
		UnityWebRequest www = UnityWebRequest.Get ("https://i6.cims.nyu.edu/~kss394/");
		yield return www.SendWebRequest ();
		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
		}
		else {
			Debug.Log (www.downloadHandler.text);
		}
	}

	IEnumerator Upload() {
		List<IMultipartFormSection> formData = new List<IMultipartFormSection> ();
		string prompt = choosePrompt ();
		formData.Add (new MultipartFormDataSection ("field1="+prompt));
		//formData.Add (new MultipartFormFileSection ("my file data", "myfile.txt"));
		UnityWebRequest www = UnityWebRequest.Post ("https://i6.cims.nyu.edu/~kss394/", formData);
		yield return www.SendWebRequest ();
		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
		}
		else {
			Debug.Log ("Form upload complete");
		}
		Debug.Log (formData [0]);
	}

	public string choosePrompt() {
		return partsOfSpeech [Random.Range (0, partsOfSpeech.Length)];
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Upload ();
		}
	}
}