using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    private float cooldown;

    private float lastShootTime;

    private GameObject ammo;

    private GameObject gun;

    private float ammo_speed;

    private Vector2 lookAt;

	// Use this for initialization
	void Start () {
        lookAt = Vector2.right;
        lastShootTime = Time.time;
        cooldown = GameManager.GetManager().ShootCooldown;
        ammo = GameManager.GetManager().Ammo;
        ammo_speed = GameManager.GetManager().AmmoSpeed;
        gun = GameObject.Find("Gun");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Fire") > 0.0f && lastShootTime <= Time.time) {
            lookAt = transform.right;
            Shoot();
        }
	}

    void Shoot() {

        AudioManager.GetManager().PlayShoot();

        GameObject go = (GameObject)Instantiate(ammo, gun.transform.position, Quaternion.identity);

        go.GetComponent<Rigidbody2D>().velocity = lookAt * ammo_speed;

        lastShootTime = cooldown + Time.time;

        
    }
}
