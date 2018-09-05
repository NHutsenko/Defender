using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class UIControl : CachedMonoBehaviour {

        private const int MaxLevel = 30;

        #region DefendPlayStyle
        [SerializeField]
        private Button _fire;
        [SerializeField]
        private Button _water;
        [SerializeField]
        private Button _earth;
        [SerializeField]
        private Button _wind;
        #endregion

        #region AttackPlayStyle

        [SerializeField]
        private Button _attackButton;
        [SerializeField]
        private Button _aSpeedButton;

        [SerializeField]
        private Button _armorButon;
        #endregion

        [SerializeField]
        private Text _sPointsText;

        [SerializeField]
        private Text _pointsText;

        [SerializeField]
        private bool _defend;

        void Start() {
            if (_defend) {
                if (_fire != null)
                    _fire.onClick.AddListener(TaksFire);
                if (_water != null)
                    _water.onClick.AddListener(TaksWater);
                if (_earth != null)
                    _earth.onClick.AddListener(TaksEarth);
                if (_wind != null)
                    _wind.onClick.AddListener(TaskWind);
            } else if (!_defend) {
                if(_attackButton != null)
                    _attackButton.onClick.AddListener(TaskAttack);
                if(_armorButon != null)
                    _armorButon.onClick.AddListener(TaskArmor);
                if(_aSpeedButton != null)
                    _aSpeedButton.onClick.AddListener(TaskAttackSpeed);
            }
        }

        void Update() {
            UpdateSPoints();
            UpdatePointsAndWave();
        }

        private void TaksFire() {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.FireLevel >= MaxLevel)
                return;
            CachedStatsManager.CrossbowAttack += 1;
            CachedStatsManager.FireLevel++;
            CachedGameController.SPoints--;
        }

        private void TaksWater() {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.WaterLevel >= MaxLevel)
                return;
            if (CachedStatsManager.WaterLevel % 2 == 0)
                CachedStatsManager.TowerAttack += 1;
            CachedStatsManager.WaterLevel++;
            CachedGameController.SPoints--;
        }

        private void TaksEarth() {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.EarthLevel >= MaxLevel)
                return;
            CachedStatsManager.EarthLevel++;
            CachedStatsManager.TowerArmor += 1;
            CachedGameController.SPoints--;
        }

        private void TaskWind() {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.WindLevel >= MaxLevel)
                return;
            CachedStatsManager.WindLevel++;
            CachedStatsManager.CrossbowAttackSpeed -= 0.02f;
            CachedGameController.SPoints--;
        }

        private void TaskAttack()
        {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.UnitAttack >= 30)
                return;
            CachedStatsManager.UnitAttack++;
            CachedGameController.SPoints--;
        }

        private void TaskAttackSpeed() {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.UnitAttackSpeed <= .5f)
                return;
            CachedStatsManager.UnitAttackSpeed -= 0.0125f;
            CachedGameController.SPoints--;
        }

        private void TaskArmor() {
            if (CachedGameController.SPoints <= 0 || CachedStatsManager.UnitArmor >= 30)
                return;
            CachedStatsManager.UnitArmor++;
            CachedGameController.SPoints--;
        }

        private void UpdateSPoints() {
            Debug.Assert(_sPointsText != null, "_sPointsText != null");
            _sPointsText.text = "Skill Points: " + CachedGameController.SPoints;
        }

        private void UpdatePointsAndWave() {
            if (_pointsText != null)
                _pointsText.text = "Points: " + CachedGameController.Points +
                    " Wave: " + CachedGameController.Wave;
        }
    }
}
