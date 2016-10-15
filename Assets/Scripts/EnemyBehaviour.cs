using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private float speed;

    private GameObject player;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GameManager.GetManager().EnemySpeed;
	}
	
	// Update is called once per frame
	void Update () {

        //Il cherche à se rapprocher de lui
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        //Et le regarde
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;

        }
    }
}
