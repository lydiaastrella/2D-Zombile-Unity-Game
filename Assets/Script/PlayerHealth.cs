using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Text healthText;
	public SimpleHealthBar healthBar;
	public int health = 100;
	public Animator animator;

	public void TakeDamage(int damage)
	{
		health -= damage;
		healthBar.UpdateBar (health, 100);
		if (health > 0) {
			healthText.text = health.ToString ();
		}else if (health <= 0) {
			healthText.text = "0";
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
