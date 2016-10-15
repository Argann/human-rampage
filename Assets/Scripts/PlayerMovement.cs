using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    private float xSpeed;

    private float ySpeed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = GameManager.GetManager().PlayerXSpeed;
        ySpeed = GameManager.GetManager().PlayerYSpeed;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0.0f) {
            transform.rotation = x > 0.0f ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        }

        rb.velocity = new Vector2(xSpeed * x * Time.deltaTime, ySpeed * y * Time.deltaTime);
    }

}
