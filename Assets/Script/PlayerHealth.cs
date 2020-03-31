using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;
	public Animator animator;

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
		animator.SetBool ("isDead", true);
		Invoke ("DestroyPlayer", 1.2f);
		//GetComponent<BoxCollider2D> ().enabled = false;
		//GetComponent<CircleCollider2D> ().enabled = false;
		//GetComponent<Collider2D> ().enabled = false;
		//this.enabled = false;
	}

	void DestroyPlayer(){
		Destroy (gameObject);
	}

}
