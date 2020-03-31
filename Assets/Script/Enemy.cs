using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour {

	public GameManager gameManager;

	public Text scoreText;
	public int health = 100;
	public Transform player;
	public bool isFlipped = true;

	public Transform attackPoint;

	public Vector3 attackOffset;
	public float attackRange = 0.5f;
	public LayerMask playerLayers;

	public int attackDamage = 10;

	public Animator animator;

	public void LookAtPlayer(){
		if (player != null) {
			Vector3 flipped = transform.localScale;
			flipped.z *= -1f;

			if (transform.position.x > player.transform.position.x && !isFlipped) {
				transform.localScale = flipped;
				transform.Rotate (0f, 180f, 0f);
				isFlipped = true;
			} else if (transform.position.x < player.transform.position.x && isFlipped) {
				transform.localScale = flipped;
				transform.Rotate (0f, 180f, 0f);
				isFlipped = false;
			}
		}
	}

	public void Attack(){
		/*PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
		Debug.Log (playerHealth);
		playerHealth.TakeDamage (attackDamage);*/	

		Collider2D[] hitPlayers = Physics2D.OverlapCircleAll (attackPoint.position, attackRange, playerLayers);
		foreach(Collider2D p in hitPlayers){
			p.GetComponent<PlayerHealth> ().TakeDamage (attackDamage);
		}
	}

	void OnDrawGizmosSelected(){

		if (attackPoint == null) {
			return;
		}
		Gizmos.DrawWireSphere (attackPoint.position, attackRange);
	}
		
	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0) {
			animator.SetBool ("isDead", true);
			int score = Int32.Parse (scoreText.text.ToString ());
			score += 10;
			scoreText.text = score.ToString ();
			Invoke("Die",1.2f);
		}
	}

	void Die(){
		gameManager.enemiesCount -= 1;
		Debug.Log (gameManager.enemiesCount);
		Destroy (gameObject);
	}
}
