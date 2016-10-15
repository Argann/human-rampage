using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    /**
     * ====================================================
     *                     JOUEUR
     * ====================================================
     */
    [Header("Joueur")]

    [SerializeField]
    [Range(100.0f, 300.0f)]
    private int playerHealth;

    public int PlayerHealth {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    [Space(10)]

    [SerializeField]
    [Range(100.0f, 300.0f)]
    private float playerXSpeed;

    public float PlayerXSpeed {
        get { return playerXSpeed; }
        set { playerXSpeed = value; }
    }

    [SerializeField]
    [Range(100.0f, 300.0f)]
    private float playerYSpeed;

    public float PlayerYSpeed {
        get { return playerYSpeed; }
        set { playerYSpeed = value; }
    }

    /**
     * ====================================================
     *                     MUNITIONS
     * ====================================================
     */
    [Header("Munitions")]

    [SerializeField]
    private GameObject ammo;

    public GameObject Ammo {
        get { return ammo; }
        set { ammo = value; }
    }

    [SerializeField]
    private int ammoHitPoints;

    public int AmmoHitPoints {
        get { return ammoHitPoints; }
        set { ammoHitPoints = value; }
    }

    [SerializeField]
    private float ammoSpeed;

    public float AmmoSpeed {
        get { return ammoSpeed; }
        set { ammoSpeed = value; }
    }

    [SerializeField]
    [Range(0.2f, 1.0f)]
    private float shootCooldown;

    public float ShootCooldown {
        get { return shootCooldown; }
        set { shootCooldown = value; }
    }


    /**
     * ====================================================
     *                     ENNEMI
     * ====================================================
     */
    [Header("Ennemi")]

    [SerializeField]
    private GameObject enemy;

    public GameObject Enemy {
        get { return enemy; }
        set { enemy = value; }
    }

    [Space(10)]

    [SerializeField]
    private int enemyHealth;

    public int EnemyHealth {
        get { return enemyHealth; }
        set { enemyHealth = value; }
    }

    [SerializeField]
    private float enemySpeed;

    public float EnemySpeed {
        get { return enemySpeed; }
        set { enemySpeed = value; }
    }

    [Space(10)]

    [SerializeField]
    private int enemyDamage;

    public int EnemyDamage {
        get { return enemyDamage; }
        set { enemyDamage = value; }
    }

    [SerializeField]
    private float cooldownEnemy;

    public float CooldownEnemy {
        get { return cooldownEnemy; }
        set { cooldownEnemy = value; }
    }

    [Space(10)]

    [SerializeField]
    private float enemySpawnTime;

    public float EnemySpawnTime {
        get { return enemySpawnTime; }
        set { enemySpawnTime = value; }
    }

    [SerializeField]
    private Transform[] spawnPoints;

    public Transform[] SpawnPoints {
        get { return spawnPoints; }
        set { spawnPoints = value; }
    }

    /**
     * ====================================================
     *                     MISC
     * ====================================================
     */

    [Header("Misc")]
    [SerializeField]
    private float minZ;

    public float MinZ {
        get { return minZ; }
        set { minZ = value; }
    }
    [SerializeField]
    private float maxZ;

    public float MaxZ {
        get { return maxZ; }
        set { maxZ = value; }
    }
    [SerializeField]
    private float minY;

    public float MinY {
        get { return minY; }
        set { minY = value; }
    }
    [SerializeField]
    private float maxY;

    public float MaxY {
        get { return maxY; }
        set { maxY = value; }
    }


    public static GameManager GetManager() {
        return GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
