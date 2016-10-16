using UnityEngine;
using System.Collections;

public class EnemyAttackBehaviour : MonoBehaviour {

    private float cooldown;
    private float cooldownT;

    private int enemyDamage;

    // Use this for initialization
    void Start () {
        cooldown = GameManager.GetManager().CooldownEnemy;
        enemyDamage = GameManager.GetManager().EnemyDamage;
        cooldownT = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            transform.parent.GetComponent<Animator>().SetBool("attack", true);
            transform.parent.GetComponent<EnemyBehaviour>().IsAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            transform.parent.GetComponent<Animator>().SetBool("attack", false);
            transform.parent.GetComponent<EnemyBehaviour>().IsAttacking = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cooldownT <= Time.time)
        {
            other.gameObject.GetComponent<PlayerHealth>().Hit(enemyDamage);
            cooldownT = cooldown + Time.time;
        }
    }
}
