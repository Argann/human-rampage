using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class EnnemyHealth : MonoBehaviour {

    [SerializeField]
    [Range(10, 200)]
    private int maxHealth;

    private int health;

	// Use this for initialization
	void Start () {
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
        Destroy(gameObject);
    }
}
