using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Text highscore;

	// Use this for initialization
	void Start () {
        highscore.text += PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update () {
	    if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("main_scene");
        }
	}
}
