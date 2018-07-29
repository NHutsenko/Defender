using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SkeletonStats : CatchedMonoBehaviour, IPooledObject {
    private float _attackRate;
    private float _nextAttack;

    private StatsController _player;

    public void OnObjectSpawn() {
        CatchedStats.Damage.AddStat(CatchedGameController.EnemyAttack);
        CatchedStats.Armor.AddStat(CatchedGameController.EnemyArmor);
        _attackRate = CatchedGameController.EnemyAttackSpeed;
        _player = GameObject.Find("crossbow").GetComponent<StatsController>();
    }

    private void Update() {
        if (!gameObject.activeInHierarchy) return;
        if (transform.position.x != -9.5f || !(Time.time > _nextAttack)) return;
        _nextAttack = Time.time + _attackRate;
        _player.TakeDamage(CatchedGameController.EnemyAttack);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("FireBall")) {
            CatchedStats.TakeDamage(CatchedGameController.TowerAttack);
        }
        if (!collision.gameObject.CompareTag("Arrow")) return;
        CatchedStats.TakeDamage(CatchedGameController.PlayerAttack);
    }
}
