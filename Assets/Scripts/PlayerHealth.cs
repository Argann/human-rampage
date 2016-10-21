using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

    private int maxHealth;

    private Image fadeOut;

    public int MaxHealth {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    [SerializeField]
    private Sprite death;


    private int currentHealth;

	// Use this for initialization
	void Start () {
        maxHealth = GameManager.GetManager().PlayerHealth;
        currentHealth = maxHealth;
        GameManager.GetManager().CurrentPlayerHealth = currentHealth;
        fadeOut = GameObject.Find("FADEOUT").GetComponent<Image>();
        fadeOut.canvasRenderer.SetAlpha(1.0f);
        fadeOut.CrossFadeAlpha(0.0f, 1.0f, false);
    }
	
	public void Hit(int damage) {
        currentHealth -= damage;
        GameManager.GetManager().CurrentPlayerHealth = currentHealth;
        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
		GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("AttackLoot");
		foreach (GameObject current in toDestroy) {
			Destroy (current);
		}
		toDestroy = GameObject.FindGameObjectsWithTag("HealLoot");
		foreach (GameObject current in toDestroy) {
			Destroy (current);
		}
		toDestroy = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject current in toDestroy) {
			Destroy (current);
		}
        GetComponent<Animator>().SetBool("dead", true);
        AudioManager.GetManager().PlayDie();
        if (PlayerPrefs.GetInt("highscore", 0) < ScoreManager.GetManager().GetScore())
        {
            PlayerPrefs.SetInt("highscore", ScoreManager.GetManager().GetScore());
        }
        StartCoroutine(quit());
    }

    IEnumerator quit() {
        fadeOut.CrossFadeAlpha(1.0f, 1.0f, false);
        while (fadeOut.canvasRenderer.GetAlpha() < 0.9f) {
            yield return null;
        }
        SceneManager.LoadScene("final_scene");
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
