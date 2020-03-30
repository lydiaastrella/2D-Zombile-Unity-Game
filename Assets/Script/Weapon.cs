using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public Animator animator;
	public AudioSource shootingAudio;
	public AudioClip fireClip;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			animator.SetBool ("isShooting", true);
			shootingAudio.clip = fireClip;
			shootingAudio.Play ();
			Shoot ();
			Invoke ("SetBoolBack", 0.5f);
		}
	}

	void SetBoolBack(){
		animator.SetBool ("isShooting", false);
	}

	void Shoot(){
		Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
