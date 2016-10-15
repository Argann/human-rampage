using UnityEngine;
using System.Collections;

public class EnemyAttackBehaviour : MonoBehaviour {

    private float cooldown;
    private float cooldownT;

    // Use this for initialization
    void Start () {
        cooldown = GameManager.GetManager().CooldownEnemy;
        cooldownT = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldownT > 0)
        {
            cooldownT -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && cooldownT <= 0)
        {
            print("You're gonna die fucker.");
            cooldownT = cooldown;
        }
    }
}
