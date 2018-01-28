using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InterfaceWithServer : MonoBehaviour {

	public float timer;
//	public string[] partsOfSpeech;
	int count;

	public string baseURL = "https://i6.cims.nyu.edu/~kss394/Digestion/opt/GlobalGameJam2018/JS";

	void Start () {
		//StartCoroutine (GetWords ());
//		count = 0;
	}
		
	IEnumerator GetWords() {
		UnityWebRequest www = UnityWebRequest.Get (baseURL+"/api/endround");
		yield return www.SendWebRequest ();
		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
		}
		else {
			Debug.Log (www.downloadHandler.text);
		}
	}

	IEnumerator Upload(int wordNumber) {
		List<IMultipartFormSection> formData = new List<IMultipartFormSection> ();
//		string prompt = partsOfSpeech [wordNumber];
//		formData.Add (new MultipartFormDataSection ("field1="+prompt));
		//formData.Add (new MultipartFormFileSection ("my file data", "myfile.txt"));
		UnityWebRequest www = UnityWebRequest.Post (baseURL+"/api/startround", formData);
		yield return www.SendWebRequest ();
		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
			Debug.Log(www);
		}
		else {
			Debug.Log ("Form upload complete");
			Debug.Log(www.downloadHandler.text);
		}
	}

//	public string choosePrompt(int wordNumber) {
//		//return partsOfSpeech [Random.Range (0, partsOfSpeech.Length)];
//		return partsOfSpeech [wordNumber];
//	}

//	void Update () {
//		if (Input.GetKeyDown(KeyCode.Space)) {
//			StartCoroutine(Upload(count));
//			count++;
//			if (count>partsOfSpeech.Length) {
//				count = 0;
//			}
//		}
//		if (Input.GetKeyDown(KeyCode.E)) {
//			StartCoroutine(GetWords());
//		}
//	}
}