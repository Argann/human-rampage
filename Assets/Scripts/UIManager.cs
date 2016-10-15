using UnityEngine;
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
        life.text = GameManager.GetManager().CurrentPlayerHealth + "/" + GameManager.GetManager().PlayerHealth;
        life_image.fillAmount = (float)GameManager.GetManager().CurrentPlayerHealth / (float)GameManager.GetManager().PlayerHealth;
        score.text = ""+ScoreManager.GetManager().GetScore();

	}
}
