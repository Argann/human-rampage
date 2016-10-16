using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndingScript : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject targetPlayer;

    [SerializeField]
    private GameObject targetOut;

    [SerializeField]
    private Image fadeOut;

    [SerializeField]
    private float fadeDuration;

	// Use this for initialization
	void Start () {
        enemy.GetComponent<Animator>().SetBool("isCinematic", true);
        fadeOut.canvasRenderer.SetAlpha(1.0f);
        fadeOut.CrossFadeAlpha(0.0f, fadeDuration, false);
        StartCoroutine(animate());
    }

    void Update() {
        if (Input.GetAxisRaw("Fire") > 0.0f) {
            StartCoroutine(quit());
        }
    }

    IEnumerator animate() {
        
        while (enemy.transform.position.x < targetPlayer.transform.position.x-0.5) {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPlayer.transform.position, 1.8f * Time.deltaTime);
            yield return null;
        }
        enemy.GetComponent<Animator>().SetBool("idle", true);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(quit());

    }

    IEnumerator quit() {
        fadeOut.CrossFadeAlpha(1.0f, fadeDuration, false);
        while (fadeOut.canvasRenderer.GetAlpha() < 1.0f) {
            yield return null;
        }
        SceneManager.LoadScene("Menu");
    }
	
	
}
