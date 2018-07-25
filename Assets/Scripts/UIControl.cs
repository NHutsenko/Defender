using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : CatchedMonoBehaviour {

    [SerializeField]
    private Button fire;
    [SerializeField]
    private Button water;
    [SerializeField]
    private Button earth;
    [SerializeField]
    private Button wind;
    [SerializeField]
    private Text pointsText;

    void Start () {
        fire.onClick.AddListener(TaksFire);
        water.onClick.AddListener(TaksWater);
        earth.onClick.AddListener(TaksEarth);
        wind.onClick.AddListener(TaskWind);
	}
	
	void Update () {
        UpdatePoints();
        //ShowStats();
	}

    private void TaksFire() {
        if (CatchedGameController.Points <= 0) return;
        CatchedGameController.PlayerAttack += 1;
        CatchedGameController.Points--;
    }

    private void TaksWater() {
        if (CatchedGameController.Points <= 0) return;
        CatchedGameController.TowerAttack += 1;
        CatchedGameController.Points--;
    }

    private void TaksEarth() {
        if (CatchedGameController.Points <= 0) return;
        CatchedGameController.TowerArmor += 1;
        CatchedGameController.Points--;
    }

    private void TaskWind() {
        if (CatchedGameController.Points <= 0) return;
        CatchedGameController.PlayerAttackSpeed += 0.05f;
        CatchedGameController.Points--;
    }

    private void UpdatePoints() {
        pointsText.text = "Points: " + CatchedGameController.Points;
    }

    // for debug mode
    void ShowStats() {
        Logger.LogMessage("Attack" + CatchedGameController.PlayerAttack);
        Logger.LogMessage("Attack speed" + CatchedGameController.PlayerAttackSpeed);
        Logger.LogMessage("Armor" + CatchedGameController.TowerArmor);
        Logger.LogMessage("Tower Attack" + CatchedGameController.TowerAttack);
    }
}
