using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Ammo : MonoBehaviour {

    [SerializeField]
    private int hitPoints;

    public int HitPoints {
        get { return hitPoints; }
        set { hitPoints = value; }
    }

    void Start() {
        gameObject.tag = "Ammo";
    }



}
