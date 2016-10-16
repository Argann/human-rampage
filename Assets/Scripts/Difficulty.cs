using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    private int level;

    private float timeLevel;

    private float nextLevel;

    private int enemyDamageBoost;

    private int enemyHealthBoost;

    private float enemySpeedBoost;

    void Start() {
        level = 1;
        timeLevel = GameManager.GetManager().TimeLevel;
        enemyDamageBoost = GameManager.GetManager().EnemyAttackBoost;
        enemyHealthBoost = GameManager.GetManager().EnemyHealthBoost;
        enemySpeedBoost = GameManager.GetManager().EnemySpeedBoost;
        nextLevel = Time.time + timeLevel;

        StartCoroutine(startTime());
    }

    IEnumerator startTime() {
        while (true) {
            
            if (Time.time >= nextLevel) {
                level += 1;
                GameManager.GetManager().EnemyDamage += enemyDamageBoost;
                GameManager.GetManager().EnemyHealth += enemyHealthBoost;
                GameManager.GetManager().EnemySpeed += enemySpeedBoost;
                nextLevel = Time.time + timeLevel;
            }

            GameManager.GetManager().CurrentTimeLevel = Mathf.InverseLerp(nextLevel-timeLevel, nextLevel, Time.time);
            GameManager.GetManager().CurrentLevel = level;
            print(GameManager.GetManager().CurrentTimeLevel);
            yield return null;

        }
    }
}
