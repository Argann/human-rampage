using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private int hp;
    public int HP
    {
        get { return hp; }
    }


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        //Il cherche à se rapprocher de lui
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

        //Et le regarde
        Vector3 dir = mousePosition - transform.position;
        this.GetComponent<SpriteRenderer>().flipX = (dir.x < 0);
    }

    public void Attack(int value)
    {
        hp -= value;
        if (hp == 0)
        {
            Destroy(this);
        }
    }
}
