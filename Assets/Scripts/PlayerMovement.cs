using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {

    private float xSpeed;

    private float ySpeed;

    private Rigidbody2D rb;

    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = GameManager.GetManager().PlayerXSpeed;
        ySpeed = GameManager.GetManager().PlayerYSpeed;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0.0f) {
            transform.localScale = x < 0.0f ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
        }

        anim.SetBool("idle", (x == 0.0f && y == 0.0f));


        rb.velocity = new Vector2(xSpeed * x * Time.deltaTime, ySpeed * y * Time.deltaTime);
    }


    public static Animator GetPlayerAnimator() {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

}
