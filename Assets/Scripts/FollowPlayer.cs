using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public float dampTime = 0.50f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0 - Camera.main.orthographicSize);
            Vector3 point = Camera.main.WorldToViewportPoint(targetPosition);
            Vector3 delta = targetPosition - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, point.z)); 
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
