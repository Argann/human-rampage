using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]                         // Pour voir les arguments "private" dans "inspector" de unity   
    private GameObject enemy;                // The enemy prefab to be spawned.
    [SerializeField]
    private float spawnTime = 3f;            // How long between each spawn.
    [SerializeField]
    private Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawner", spawnTime, spawnTime);
    }


    void Spawner()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}