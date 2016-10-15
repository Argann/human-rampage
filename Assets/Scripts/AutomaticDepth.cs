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
        float y_percent = ((transform.position.y - minY) * 100) / (maxY - minY);
        ChangeZ((y_percent * (maxZ - minZ) / 100) + minZ);
    }


    void ChangeZ(float z) {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
	
	
}
