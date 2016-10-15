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

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cooldownT <= Time.time)
        {
            other.gameObject.GetComponent<PlayerHealth>().Hit(enemyDamage);
            cooldownT = cooldown + Time.time;
        }
    }
}
