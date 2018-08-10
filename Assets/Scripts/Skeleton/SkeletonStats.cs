using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SkeletonStats : CachedMonoBehaviour, IPooledObject {
    private float _attackRate;
    private float _nextAttack;

    private StatsController _player;

    public void OnObjectSpawn() {
        CachedStats.Damage.AddStat(CachedGameController.EnemyAttack);
        CachedStats.Armor.AddStat(CachedGameController.EnemyArmor);
        _attackRate = CachedGameController.EnemyAttackSpeed;
        _player = GameObject.Find("crossbow").GetComponent<StatsController>();
    }

    private void Update() {
        if (!gameObject.activeInHierarchy) return;
        if (transform.position.x != -9.5f || !(Time.time > _nextAttack))
            return;
        _nextAttack = Time.time + _attackRate;
        _player.TakeDamage(CachedGameController.EnemyAttack);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("FireBall")) {
            CachedStats.TakeDamage(CachedGameController.TowerAttack);
        }
        if (!collision.gameObject.CompareTag("Arrow"))
            return;
        CachedStats.TakeDamage(CachedGameController.PlayerAttack);
    }
}
