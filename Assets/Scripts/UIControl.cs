using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIControl : CatchedMonoBehaviour {

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

        void Start () {
            _fire.onClick.AddListener(TaksFire);
            _water.onClick.AddListener(TaksWater);
            _earth.onClick.AddListener(TaksEarth);
            _wind.onClick.AddListener(TaskWind);
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
