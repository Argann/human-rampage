using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    private Vector3 originPosition;
    private Quaternion originRotation;
    private float shake_decay;
    private float shake_intensity;

    void Update() {
        if (shake_intensity > 0) {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity -= shake_decay;
        }
    }

    public void Shake(float intensity, float shake_decay) {
        originPosition = transform.position;
        originRotation = transform.rotation;
        this.shake_intensity = intensity;
        this.shake_decay = shake_decay;
    }

    public static void CamShake(float intensity = 0.02f, float shake_decay = 0.002f) {
        GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(intensity, shake_decay);
    }
}
