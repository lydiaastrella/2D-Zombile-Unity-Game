using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	public Text dataText;
	public Canvas canvas;

	string[] separator = { "," , ":"};
	float offset = 150;

	// Use this for initialization
	void Start () {
		Debug.Log ("start scoreboard");

		string URL = "134.209.97.218:5051/scoreboards/13517019";

		WWW www = new WWW (URL);
		StartCoroutine (GetData(www));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GetData (WWW www){
		yield return www;
		if (www.error != null) {
			Debug.Log (www.error);
		} else {
			Debug.Log (www.text);

			string jsonString = www.text.Replace ("{", string.Empty);
			jsonString = jsonString.Replace ("}", string.Empty);
			jsonString = jsonString.Replace ("[", string.Empty);
			jsonString = jsonString.Replace ("]", string.Empty);
			jsonString = jsonString.Replace ("\"", string.Empty);
			Debug.Log (jsonString);

			string[] dataObject = jsonString.Split (separator, 80, System.StringSplitOptions.RemoveEmptyEntries);
			Debug.Log (dataObject [5]);
			Debug.Log (dataObject [7]);


			for (int i = 5; i < dataObject.Length; i+=8) {
				offset -= 30;
				Vector3 position = new Vector3 (0f, offset, 0f);
				Text cloneText = Instantiate (dataText, position, Quaternion.identity) as Text;

				cloneText.transform.SetParent (canvas.transform, false);

				cloneText.text = " USERNAME : " + dataObject[i] + " , SCORE : " + dataObject[i+2];
				cloneText.gameObject.SetActive (true);
			}
		}
	}
}