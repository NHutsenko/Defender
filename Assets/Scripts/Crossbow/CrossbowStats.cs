using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CrossbowStats : StatsController {

    private float _nextHealth;
    private float _healthRate;

    protected override void Start()
    {
        base.Start();
        _healthRate = 3f;
    }
    private void LateUpdate()
    {
        if (CachedStatsManager.HealthRegeneration <= 0)
            return;
        if (!(Time.time > _nextHealth))
            return;
        _nextHealth = Time.time + _healthRate;
        HealthRegeneration(CachedStatsManager.HealthRegeneration);
    }
}
