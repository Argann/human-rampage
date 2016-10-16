using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    private int maxHealth;

    public int MaxHealth {
        get { return maxHealth; }
        set { maxHealth = value; }
    }


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
        if (PlayerPrefs.GetInt("highscore", 0) < ScoreManager.GetManager().GetScore())
        {
            PlayerPrefs.SetInt("highscore", ScoreManager.GetManager().GetScore());
        }
        SceneManager.LoadScene("menu");
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
