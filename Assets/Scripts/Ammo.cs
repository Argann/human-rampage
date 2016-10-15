using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Ammo : MonoBehaviour {

    private int hitPoints;

    public int HitPoints {
        get { return hitPoints; }
        set { hitPoints = value; }
    }

    void Start() {
        hitPoints = GameManager.GetManager().AmmoHitPoints;
        gameObject.tag = "Ammo";
    }



}
