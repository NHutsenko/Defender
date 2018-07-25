using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStats : CatchedMonoBehaviour, IPooledObject {

    float attackRate, nextAttack;

    StatsController player;

    public void OnObjectSpawn() {
        CatchedStats.Damage.AddStat(CatchedGameController.EnemyAttack);
        CatchedStats.Armor.AddStat(CatchedGameController.EnemyArmor);
        attackRate = CatchedGameController.EnemyAttackSpeed;
        player = GameObject.Find("crossbow").GetComponent<StatsController>();
    }

    private void Update() {
        if (gameObject.activeInHierarchy) {
            if (transform.position.x == -9.5f && Time.time > nextAttack) {
                nextAttack = Time.time + attackRate;
                player.TakeDamage(CatchedGameController.EnemyAttack);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Arrow")) {
            CatchedStats.TakeDamage(CatchedGameController.PlayerAttack);
        }
    }
}
