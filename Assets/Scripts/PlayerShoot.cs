using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    [Range(0.2f, 1.0f)]
    private float cooldown;

    private float lastShootTime;

    [SerializeField]
    private GameObject ammo;

    [SerializeField]
    [Range(1.0f, 500.0f)]
    private float ammo_speed;

    private Vector2 lookAt;

	// Use this for initialization
	void Start () {
        lookAt = Vector2.right;
        lastShootTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Fire") > 0.0f && lastShootTime <= Time.time) {
            lookAt = transform.right;
            Shoot();
        }
	}

    void Shoot() {
        Debug.Log("Let's go !");
        GameObject go = (GameObject)Instantiate(ammo, transform.position, Quaternion.identity);

        Debug.Log(lookAt);

        go.GetComponent<Rigidbody2D>().velocity = lookAt * ammo_speed;

        lastShootTime = cooldown + Time.time;

        
    }
}
