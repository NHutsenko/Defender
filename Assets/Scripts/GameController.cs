using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : CatchedMonoBehaviour {

    private float spawnWait;
    private int enemiesCount;
    private bool nextWave;
    private int points;
    private int alivedEnemies;
    private bool spawnDefender;

    public int AlivedEnemies {
        set { alivedEnemies = value; }
        get { return alivedEnemies; }
    }

    #region stats
    private int enemyAttack;
    private int enemyArmor;
    private float enemyAttackSpeed;

    private int playerAttack;
    private int towerArmor;
    private int towerAttack;
    private float playerAttackSpeed;
    public int EnemyAttack { get { return enemyAttack; } }
    public int EnemyArmor { get { return enemyArmor; } }

    public float EnemyAttackSpeed { get { return enemyAttackSpeed; } }
    public int PlayerAttack {
        get { return playerAttack; }
        set { playerAttack = value; }
    }
    public int TowerAttack {
        get { return towerAttack; }
        set { towerAttack = value; }
    }
    public int TowerArmor {
        get { return towerArmor; }
        set { towerArmor = value; }
    }

    public float PlayerAttackSpeed {
        get { return playerAttackSpeed; }
        set { playerAttackSpeed = value; }
    }

    public int Points {
        get { return points; }
        set { points = value; }
    }
    #endregion


    void Start () {
        playerAttackSpeed = 1f;
        enemyAttackSpeed = 1f;
        spawnWait = 1f;
        enemiesCount = 5;
        StartCoroutine(SpawnWawes(0));
        enemyAttack = 1;
        enemyArmor = 0;
        points = 0;
        playerAttackSpeed = 0.7f;
        playerAttack = 30;
        alivedEnemies = 5;
    }
	
	void LateUpdate () {
        if(alivedEnemies == 0) {
            alivedEnemies = 5;
            enemyAttack++;
            enemyArmor++;
            points += 2;
            StartCoroutine(SpawnWawes(5));
        }
        Logger.LogMessage("Enemies alived " + alivedEnemies);
	}

    IEnumerator SpawnWawes(float startDelay) {
        yield return new WaitForSeconds(startDelay);
        for (int i = 0; i < enemiesCount; i++) {
            Vector2 spawnPosition = new Vector2(13, Random.Range(-4.5f, 4.5f));
            Quaternion spawnRotation = Quaternion.identity;
            ObjectPooler.Instance.SpawnObject((int)Tags.Skeleton, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    void SpawnDefender(Vector2 pos, Quaternion rot) {
        spawnDefender = false;
        ObjectPooler.Instance.SpawnObject((int)Tags.Defender, pos, rot);
    }
}
