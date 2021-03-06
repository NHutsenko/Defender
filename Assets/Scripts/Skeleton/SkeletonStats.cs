﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SkeletonStats : CachedMonoBehaviour, IPooledObject {
    private float _attackRate;
    private float _nextAttack;

    private StatsController _crossbowStats;

    public void OnObjectSpawn() {
        CachedStats.Damage.AddStat(CachedStatsManager.UnitAttack);
        CachedStats.Armor.AddStat(CachedStatsManager.UnitArmor);
        _attackRate = CachedStatsManager.UnitAttackSpeed;
        _crossbowStats = GameObject.Find("crossbow").GetComponent<StatsController>();
    }

    private void Update() {
        if (!gameObject.activeInHierarchy) return;
        if (transform.position.x != -9.5f || !(Time.time > _nextAttack))
            return;
        _nextAttack = Time.time + _attackRate;
        if (_crossbowStats != null)
            _crossbowStats.TakeDamage(CachedStats.Damage.Value);
    }

    void LateUpdate() {
        UpdateStats();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("FireBall")) {
            CachedStats.TakeDamage(CachedStatsManager.TowerAttack);
        }
        if (!collision.gameObject.CompareTag("Arrow"))
            return;
        CachedStats.TakeDamage(CachedStatsManager.CrossbowAttack);
    }

    private void UpdateStats() {
        CachedStats.Damage.UpdateStat(CachedStatsManager.UnitAttack);
        CachedStats.Armor.UpdateStat(CachedStatsManager.UnitArmor);
        _attackRate = CachedStatsManager.UnitAttackSpeed;
    }
}
