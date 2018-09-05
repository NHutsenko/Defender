using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class WizardAttakerController : CachedMonoBehaviour, IPooledObject {

    private StatsController _crossbowStats;
    private float _nextAttack;
    private float _attackRate;

    public void OnObjectSpawn() {
        _attackRate = CachedStatsManager.UnitAttackSpeed;
        CachedStats.Damage.AddStat(CachedStatsManager.UnitAttack);
        CachedStats.Armor.AddStat(CachedStatsManager.UnitArmor);
        _crossbowStats = GameObject.Find("crossbow").GetComponent<StatsController>();
    }

    void Update() {
        if (Time.time > _nextAttack && transform.position.x == 3) {
            _nextAttack = Time.time + _attackRate;
            if (_crossbowStats != null)
                _crossbowStats.TakeDamage(CachedStats.Damage.Value);
        }
    }

    void LateUpdate() {
        UpdateStats();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
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
