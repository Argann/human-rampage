using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    private float speed;


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
        if (transform.position.x < mousePosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;

        }
    }
}
