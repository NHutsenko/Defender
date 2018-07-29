using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class UIControl : CatchedMonoBehaviour {

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
            if (CatchedGameController.Points <= 0 || CatchedGameController.FireLevel >= 30) return;
            CatchedGameController.PlayerAttack += 1;
            CatchedGameController.FireLevel++;
            CatchedGameController.Points--;
            _fire.GetComponentInChildren<Text>().text = "Fire " + CatchedGameController.FireLevel;
        }

        private void TaksWater() {
            if (CatchedGameController.Points <= 0 || CatchedGameController.WaterLevel >= 30) return;
            if (CatchedGameController.WaterLevel % 2 == 0)
                CatchedGameController.TowerAttack += 1;
            CatchedGameController.WaterLevel++;
            CatchedGameController.Points--;
            _water.GetComponentInChildren<Text>().text = "Water " + CatchedGameController.WaterLevel;
        }

        private void TaksEarth() {
            if (CatchedGameController.Points <= 0 || CatchedGameController.EarthLevel >= 30) return;
            CatchedGameController.EarthLevel++;
            CatchedGameController.TowerArmor += 1;
            CatchedGameController.Points--;
            _earth.GetComponentInChildren<Text>().text = "Earth " + CatchedGameController.EarthLevel;
        }

        private void TaskWind() {
            if (CatchedGameController.Points <= 0 || CatchedGameController.WindLevel >= 30) return;
            CatchedGameController.WindLevel++;
            CatchedGameController.PlayerAttackSpeed -= 0.02f;
            CatchedGameController.Points--;
            _wind.GetComponentInChildren<Text>().text = "Wind " + CatchedGameController.WindLevel;
        }

        private void UpdatePoints() {
            _pointsText.text = "Points: " + CatchedGameController.Points;
        }

        // for debug mode
        void ShowStats() {
            Logger.LogMessage("Attack" + CatchedGameController.PlayerAttack);
            Logger.LogMessage("Attack speed" + CatchedGameController.PlayerAttackSpeed);
            Logger.LogMessage("Armor" + CatchedGameController.TowerArmor);
            Logger.LogMessage("Tower Attack" + CatchedGameController.TowerAttack);
        }
    }
}
