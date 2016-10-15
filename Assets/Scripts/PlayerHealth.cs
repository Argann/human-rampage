using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private int maxHealth;

    private int currentHealth;

	// Use this for initialization
	void Start () {
        maxHealth = GameManager.GetManager().PlayerHealth;
        currentHealth = maxHealth;
	}
	
	public void Hit(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        AudioManager.GetManager().PlayDie();
        gameObject.SetActive(false);
    }
}
