using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    private float cooldown;

    private float lastShootTime;

    private GameObject ammo;

    private GameObject gun;

    private float ammo_speed;

    private Vector2 lookAt;

    private int cooldownBeforeCyborgisation;

	// Use this for initialization
	void Start () {
        lookAt = Vector2.right;
        lastShootTime = Time.time;
        cooldown = GameManager.GetManager().ShootCooldown;
        ammo = GameManager.GetManager().Ammo;
        ammo_speed = GameManager.GetManager().AmmoSpeed;
        gun = GameObject.Find("Gun");
        cooldownBeforeCyborgisation = GameManager.GetManager().LootsBeforeCyborgisation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Fire") > 0.0f && lastShootTime <= Time.time) {
            lookAt = new Vector2(transform.localScale.x, 0.0f);
            Shoot();
        }
	}

    void Shoot() {

        AudioManager.GetManager().PlayShoot();

        GameObject go = (GameObject)Instantiate(ammo, gun.transform.position, Quaternion.identity);

        go.GetComponent<Rigidbody2D>().velocity = lookAt * ammo_speed;

        lastShootTime = cooldown + Time.time;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("AttackLoot")) {
            AudioManager.GetManager().PlayHeal();
            ScoreManager.GetManager().AddScore(GameManager.GetManager().ScorePerLootAttack);
            GameManager.GetManager().AmmoHitPoints += GameManager.GetManager().LootAttack;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().MaxHealth += GameManager.GetManager().LootMaxHealth;
            GameManager.GetManager().PlayerHealth += GameManager.GetManager().LootMaxHealth;
            cooldownBeforeCyborgisation -= 1;
            Destroy(coll.gameObject);
        }

        if (cooldownBeforeCyborgisation <= 0) {
            cooldownBeforeCyborgisation = GameManager.GetManager().LootsBeforeCyborgisation;
            PlayerMovement.GetPlayerAnimator().SetInteger("CyborgState", PlayerMovement.GetPlayerAnimator().GetInteger("CyborgState") + 1);
        }
    }
}
