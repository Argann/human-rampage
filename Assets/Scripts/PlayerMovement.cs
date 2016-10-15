﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    [Range(1.0f, 300.0f)]
    private float xSpeed;

    [SerializeField]
    [Range(1.0f, 300.0f)]
    private float ySpeed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(xSpeed * x * Time.deltaTime, ySpeed * y * Time.deltaTime);
    }

}