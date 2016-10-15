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
        print("Ouch !");
        currentHealth -= damage;
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
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("HealLoot")) {
            AudioManager.GetManager().PlayHeal();
            Heal(GameManager.GetManager().LootHeal);
            Destroy(coll.gameObject);
        }
    }
}
