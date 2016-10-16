using UnityEngine;
using System.Collections;

public class AutomaticDepth : MonoBehaviour {


    private static float maxY;

    private static float minY;


    private static float minZ;

    private static float maxZ;


    void Start() {
        maxY = GameManager.GetManager().MaxY;
        maxZ = GameManager.GetManager().MaxZ;
        minY = GameManager.GetManager().MinY;
        minZ = GameManager.GetManager().MinZ;
    }

    void FixedUpdate() {
        float y_percent = Mathf.InverseLerp(minY, maxY, transform.position.y);
        ChangeZ(Mathf.Lerp(minZ, maxZ, y_percent));
    }


    void ChangeZ(float z) {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
	
	
}
