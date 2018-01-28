using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerComm : MonoBehaviour {

	public string testSentence = "You never digested my ass?";

	public string baseURL = "robodate.glitch.me";

	/* 
	 * Params: client==the object on which to call methodName
	 * 		methodName==name of method on client that takes 
	 * End the round on the server
	 * Receive submitted words as JSON
	 * Parse and return as string array
	 */
	public void GetResults(GameObject client, string methodName) {
		StartCoroutine(GetWords(client, methodName));
	}


	/*
	 * send round game data as JSON to server (if any is necessary for our design)
	 * Start round on server
	 * receive player info as JSON
	 * return number of players connected
	 */
	public void StartRound(GameObject client, string methodName) {
		StartCoroutine(Upload(client, methodName));
	}

	IEnumerator GetWords(GameObject client, string methodName) {
		UnityWebRequest www = UnityWebRequest.Get (baseURL+"/api/endround");
		yield return www.SendWebRequest ();
		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
		}
		else {
			string response = www.downloadHandler.text;
//			Debug.Log(response);
//			response = response.Substring(response.IndexOf(":"));
//			Debug.Log(response);
//			char[] charsToTrim = {'"', '}', ':', '[', ']'};
//			response = response.Trim(charsToTrim);
//			char[] splitchar = {','};
//			string[] arr = response.Split(splitchar);
//			Debug.Log("Responses received: " + arr.Length);
//			foreach (string s in arr) {
//				Debug.Log(s);
//			}
			char[] splitter = {' '};
			string[] arr = response.Split(splitter);
//			Debug.Log(arr.Length);
//			foreach (string s in arr) {
//				Debug.Log(s);
//			}
			client.SendMessage(methodName, arr);
		}
	}

	IEnumerator Upload(GameObject client, string methodName) {
		List<IMultipartFormSection> formData = new List<IMultipartFormSection> ();
		//		string prompt = partsOfSpeech [wordNumber];
		//		formData.Add (new MultipartFormDataSection ("field1="+prompt));
		//formData.Add (new MultipartFormFileSection ("my file data", "myfile.txt"));
		UnityWebRequest www = UnityWebRequest.Post (baseURL+"/api/startround", formData);
		yield return www.SendWebRequest ();
		if (www.isNetworkError || www.isHttpError) {
			Debug.Log (www.error);
		}
		else {
			Debug.Log ("Form upload complete");
			string response = www.downloadHandler.text;
			response = response.Substring(response.IndexOf(":"));
			char[] charsToTrim = {'"', '}', ':'};
			response = response.Trim(charsToTrim);
//			Debug.Log (response.ToString());
			client.SendMessage(methodName, response);
		}
	}

}
