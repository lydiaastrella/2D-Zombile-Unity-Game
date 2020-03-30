using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform playerTransform;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void LateUpdate () {

		if (playerTransform.position.x > -23.438 && playerTransform.position.x < 23.418) 
		{
			Vector3 temp = transform.position;
			temp.x = playerTransform.position.x;
			transform.position = temp;
		}
	}
}
