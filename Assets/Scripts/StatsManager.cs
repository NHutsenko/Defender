using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour {

    public int UnitAttack { get; set; }
    public int UnitArmor { get; set; }
    public float UnitAttackSpeed { get; set; }
    public int CrossbowAttack { get; set; }
    public int TowerAttack { get; set; }
    public int TowerArmor { get; set; }
    public float CrossbowAttackSpeed { get; set; }
    public float TowerAttackSpeed { get; set; }
    public int HealthRegeneration { get; set; }
    public int FireLevel { get; set; }
    public int EarthLevel { get; set; }
    public int WaterLevel { get; set; }
    public int WindLevel { get; set; }

    void Awake() {
        UnitAttack = 1;
        UnitArmor = 0;
        UnitAttackSpeed = 1f;
        CrossbowAttack = 20;
        CrossbowAttackSpeed = 1f;
        TowerAttack = TowerArmor = 0;
        TowerAttackSpeed = 1f;
        HealthRegeneration = 0;
        FireLevel = WaterLevel = EarthLevel = WindLevel = 0;
    }
}
