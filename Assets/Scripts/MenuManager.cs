using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Text highscore;

    [SerializeField]
    private GameObject credits;

	// Use this for initialization
	void Start () {
        highscore.text += PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !credits.activeInHierarchy)
        {
            SceneManager.LoadScene("main_scene");
        }
        if (Input.anyKeyDown && credits.activeInHierarchy)
        {
            credits.SetActive(false);
        }
	}

    public void Credits_OnClick()
    {
        credits.SetActive(true);
    }
}
