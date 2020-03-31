using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	public Text dataText;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
		Debug.Log ("start scoreboard");

		string URL = "134.209.97.218:5051/scoreboards/13517019";

		WWW www = new WWW (URL);
		StartCoroutine (GetData(www));
		/*for (int i = 0; i < 10; i++) {
			float y = 150 - (i * 30);
			Vector3 position = new Vector3 (0f, y, 0f);
			Text cloneText = Instantiate (dataText, position, Quaternion.identity) as Text;

			cloneText.transform.SetParent (canvas.transform, false);

			cloneText.text = " data ke " + i.ToString ();
			cloneText.gameObject.SetActive (true);
		}*/

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
			for (int i = 0; i < 10; i++) {
				float y = 150 - (i * 30);
				Vector3 position = new Vector3 (0f, y, 0f);
				Text cloneText = Instantiate (dataText, position, Quaternion.identity) as Text;

				cloneText.transform.SetParent (canvas.transform, false);

				cloneText.text = " data ke " + i.ToString ();
				cloneText.gameObject.SetActive (true);
			}
		}
	}
}