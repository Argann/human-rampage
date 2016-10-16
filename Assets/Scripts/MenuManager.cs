using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sprite pressedSprite = Resources.Load<Sprite>("Sprites/button-dark.png");
        //Sprite defaultSprite = Resources.Load<Sprite>("Sprites/button-dark-outline.png");
        SpriteState st = new SpriteState();
        st.pressedSprite = pressedSprite;
        GetComponent<Button>().spriteState = st;
    }

    // Update is called once per frame
    void Update () {
	    if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("main_scene");
        }
	}
}
