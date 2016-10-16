using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

    private GameObject[] backgrounds;
    private bool has_not_created;

	// Use this for initialization
	void Start () {
        has_not_created = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && has_not_created)
        {
            int rand = Random.Range(0, GameManager.GetManager().Backgrounds.Length);
            GameObject background = GameManager.GetManager().Backgrounds[rand];
            has_not_created = false;
            Instantiate(background, this.transform.position + Vector3.right * 11.62f, transform.rotation);
        }
    }
}
