using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private int maxHealth;

    private int currentHealth;

	// Use this for initialization
	void Start () {
        maxHealth = GameManager.GetManager().PlayerHealth;
        currentHealth = maxHealth;
        GameManager.GetManager().CurrentPlayerHealth = currentHealth;
    }
	
	public void Hit(int damage) {
        currentHealth -= damage;
        GameManager.GetManager().CurrentPlayerHealth = currentHealth;
        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        AudioManager.GetManager().PlayDie();
        gameObject.SetActive(false);
    }

    public void Heal(int heal) {
        currentHealth = (currentHealth + heal) <= maxHealth ? currentHealth + heal : maxHealth;
        ScoreManager.GetManager().AddScore(GameManager.GetManager().ScorePerHeal);
        GameManager.GetManager().CurrentPlayerHealth = currentHealth;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("HealLoot")) {
            AudioManager.GetManager().PlayHeal();
            Heal(GameManager.GetManager().LootHeal);
            Destroy(coll.gameObject);
        }
    }
}
