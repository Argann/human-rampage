using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private float speed;

    private GameObject player;

    private bool isAttacking;

    public bool IsAttacking {
        get { return isAttacking; }
        set { isAttacking = value; }
    }



    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = GameManager.GetManager().EnemySpeed;
        isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {

        //Il cherche à se rapprocher de lui
        if (!IsAttacking) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        

        transform.localScale = transform.position.x > player.transform.position.x ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);
    }
}
