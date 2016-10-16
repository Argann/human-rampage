using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {

    private GameObject[] backgrounds;
    private bool has_not_created;
    private static int nextBackground = 0;

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

            int rand = nextBackground++ % GameManager.GetManager().Backgrounds.Length;
            //int rand = Random.Range(0, GameManager.GetManager().Backgrounds.Length);
            GameObject background = GameManager.GetManager().Backgrounds[rand];
            has_not_created = false;
            Instantiate(background, this.transform.position + Vector3.right * 11.62f, transform.rotation);
            rand = Random.Range(0, 100);
            if (rand < 50)
            {
                int randProp = Random.Range(0, GameManager.GetManager().Props.Length);
                GameObject prop = GameManager.GetManager().Props[randProp];
                float randx = Random.Range(-3f, 4f);
                float randy = Random.Range(-3f, 2f);
                Instantiate(prop, this.transform.position + Vector3.right * 11.62f + new Vector3(randx, randy, 0), transform.rotation);
            }
        }
    }
}
