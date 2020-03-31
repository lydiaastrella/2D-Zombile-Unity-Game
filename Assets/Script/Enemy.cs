using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
	public Transform player;
	public bool isFlipped = true;

	public Transform attackPoint;

	public Vector3 attackOffset;
	public float attackRange = 0.5f;
	public LayerMask playerLayers;

	public int attackDamage = 10;

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
			Die ();
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
