﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class UIControl : CachedMonoBehaviour {

        private const int MaxLevel = 30;

        [SerializeField]
        private Button _fire;
        [SerializeField]
        private Button _water;
        [SerializeField]
        private Button _earth;
        [SerializeField]
        private Button _wind;
        [SerializeField]
        private Text _pointsText;

        void Start() {
            _fire.onClick.AddListener(TaksFire);
            _water.onClick.AddListener(TaksWater);
            _earth.onClick.AddListener(TaksEarth);
            _wind.onClick.AddListener(TaskWind);
        }

        void Update() {
            UpdatePoints();
            //ShowStats();
        }

        private void TaksFire() {
            if (CachedGameController.Points <= 0 || CachedGameController.FireLevel >= 30) return;
            CachedGameController.PlayerAttack += 1;
            CachedGameController.FireLevel++;
            CachedGameController.Points--;
        }

        private void TaksWater() {
            if (CachedGameController.Points <= 0 || CachedGameController.WaterLevel >= 30) return;
            if (CachedGameController.WaterLevel % 2 == 0)
                CachedGameController.TowerAttack += 1;
            CachedGameController.WaterLevel++;
            CachedGameController.Points--;
        }

        private void TaksEarth() {
            if (CachedGameController.Points <= 0 || CachedGameController.EarthLevel >= 30) return;
            CachedGameController.EarthLevel++;
            CachedGameController.TowerArmor += 1;
            CachedGameController.Points--;
        }

        private void TaskWind() {
            if (CachedGameController.Points <= 0 || CachedGameController.WindLevel >= 30) return;
            CachedGameController.WindLevel++;
            CachedGameController.PlayerAttackSpeed -= 0.02f;
            CachedGameController.Points--;
        }

        private void UpdatePoints() {
            _pointsText.text = "Points: " + CachedGameController.Points;
        }

        // for debug mode
        void ShowStats() {
            Logger.LogMessage("Fire " + CachedGameController.FireLevel);
            Logger.LogMessage("Water " + CachedGameController.WaterLevel);
            Logger.LogMessage("Earth " + CachedGameController.EarthLevel);
            Logger.LogMessage("Wind " + CachedGameController.WindLevel);
        }
    }
}
