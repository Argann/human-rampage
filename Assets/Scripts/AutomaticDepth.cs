using UnityEngine;
using System.Collections;

public class AutomaticDepth : MonoBehaviour {

    [SerializeField]
    private static float maxY = 100.0f;
    [SerializeField]
    private static float minY = -100.0f;

    [SerializeField]
    private static float minZ = -8.0f;
    [SerializeField]
    private static float maxZ = -6.0f;

    void FixedUpdate() {
        float y_percent = ((transform.position.y - minY) * 100) / (maxY - minY);
        ChangeZ((y_percent * (maxZ - minZ) / 100) + minZ);
    }


    void ChangeZ(float z) {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
	
	
}
