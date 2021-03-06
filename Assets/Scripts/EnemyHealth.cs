﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyHealth : MonoBehaviour {

    private int maxHealth;

    private int health;

	// Use this for initialization
	void Start () {
        maxHealth = GameManager.GetManager().EnemyHealth;
        health = maxHealth;

	}

    void Update() {
        if (health <= 0) {
            Die();
        }
    }
	
	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Ammo")) {
            AudioManager.GetManager().PlayHit();
            Destroy(coll.gameObject);
            health -= coll.GetComponent<Ammo>().HitPoints;
        }
    }

    void Die() {
        AudioManager.GetManager().PlayDie();
        Destroy(gameObject.transform.parent.gameObject);
    }
}
