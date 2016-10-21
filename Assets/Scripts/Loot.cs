using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

    private GameObject[] loots;

    private float lootChance;

	// Use this for initialization
	void Start () {
        loots = GameManager.GetManager().Loots;
        lootChance = GameManager.GetManager().LootChance;
	}
	
	void OnDestroy() {
        if (Random.Range(0.0f, 1.0f) <= lootChance) {
			GameObject loot = (GameObject) Instantiate(loots[(int)Random.Range(0, Mathf.Round(loots.Length))], transform.position, Quaternion.identity);
        }
    }
}
