﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text score;

    [SerializeField]
    private Text life;
    [SerializeField]
    private Image life_image;
	
	// Update is called once per frame
	void Update () {
        int health = GameManager.GetManager().CurrentPlayerHealth;
        life.text = (health < 0 ? "0" : health.ToString())  + "/" + GameManager.GetManager().PlayerHealth;
        life_image.fillAmount = (float)GameManager.GetManager().CurrentPlayerHealth / (float)GameManager.GetManager().PlayerHealth;
        score.text = ""+ScoreManager.GetManager().GetScore();

	}
}
