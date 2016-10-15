using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	public void AddScore(int sc) {
        score += sc;
    }

    public int GetScore() {
        return score;
    }

    public static ScoreManager GetManager() {
        return GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
}
