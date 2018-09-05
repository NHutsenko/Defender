using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class GameController : CachedMonoBehaviour {

        [SerializeField]
        private bool _defend;
        private float _spawnWait;
        private int _enemiesCount;
        private bool _nextWave;
        private int _sPoints;
        private int _spawnDefender;
        private int _arrowCounter;
        private bool _endWave;
        private int _points;
        private int _wave;

        private int _currentThresholdHitPoints;
        private StatsController _crossbowHitPoints;

        #region Player info

        public int Wave {
            get { return _wave; }

            set { _wave = value; }
        }

        public int ArrowCounter {
            get { return _arrowCounter; }
        }

        public int Points {
            get { return _points; }

            set { _points = value; }
        }

        public int SPoints {
            get {
                return _sPoints;
            }
            set {
                _sPoints = value;
            }
        }

        public int EnemiesCount {
            get {
                return _enemiesCount;
            }

            set {
                _enemiesCount = value;
            }
        }

        public bool EndWave {
            get {
                return _endWave;
            }

            set {
                _endWave = value;
            }
        }

        #endregion

        private StatsManager _statManager;

        void Start() {
            _statManager = GameObject.Find("StatManager").GetComponent<StatsManager>();
            _spawnWait = 1f;
            EnemiesCount = 5;
            if (_defend)
                StartCoroutine(SpawnWawes(0));
            _sPoints = 20;
            _arrowCounter = 1;
            _spawnDefender = 0;
            _points = 0;
            _wave = 1;
            _crossbowHitPoints = GameObject.Find("crossbow").GetComponent<StatsController>();
            _currentThresholdHitPoints = 80;
        }

        void LateUpdate() {

            if (_defend) {
                if (_nextWave) {
                    _nextWave = false;
                    CachedStatsManager.UnitAttack++;
                    CachedStatsManager.UnitArmor++;
                    if (CachedStatsManager.UnitAttackSpeed >= 0.6f)
                        CachedStatsManager.UnitAttackSpeed -= 0.05f;
                    _sPoints += 2;
                    _wave++;
                    StartCoroutine(SpawnWawes(5));
                }

                StartCoroutine(CheckWave());

                StartCoroutine(ArrowCountSpawner());
            }

            if (!_defend) {
                if (GameObject.FindGameObjectsWithTag("Enemy").Count(enemy => enemy.activeInHierarchy) == 0 && EnemiesCount == 0) {
                    EndWave = true;
                    _enemiesCount = 5;
                    if (_crossbowHitPoints.CurrentHp > 0)
                        _wave++;
                    StartCoroutine(EndWaveInfo());
                    CachedGameController.SPoints += 2;
                }

                if (_wave % 5 == 0) {
                    StartCoroutine(CheckCrossbowHitPoints());
                }

                if (_wave > 30) {
                    Debug.Log("Defender won");
                }
            }

            StartCoroutine(SpawnDefender());

            StartCoroutine(IncreaseHeal());
        }

        IEnumerator EndWaveInfo() {
            RandomAddStatsToCrossbow();
            for (int i = 5; i >= 0; i--) {
                Debug.Log("Next wave in " + i);
                yield return new WaitForSeconds(1);
            }
            EndWave = false;
        }

        void RandomAddStatsToCrossbow() {
            Random.InitState(DateTime.Now.GetHashCode());
            if (Random.Range(0, 2) == 0) {
                if (CachedStatsManager.FireLevel <= 20) {
                    CachedStatsManager.FireLevel++;
                    CachedStatsManager.CrossbowAttack++;

                    CachedStatsManager.WindLevel++;
                    CachedStatsManager.CrossbowAttackSpeed -= 0.02f;
                }
            } else {
                if (CachedStatsManager.WaterLevel <= 20) {
                    CachedStatsManager.WaterLevel++;

                    if (CachedStatsManager.WaterLevel % 2 == 0)
                        CachedStatsManager.TowerAttack += 1;

                    CachedStatsManager.EarthLevel++;
                    CachedStatsManager.TowerArmor += 1;
                }
            }
        }

        private IEnumerator CheckCrossbowHitPoints() {
            if (_crossbowHitPoints.CachedStats.CurrentHp > _currentThresholdHitPoints) {
                _currentThresholdHitPoints -= 20;
            } else {
                CachedGameController.EnemiesCount *= 2;
            }

            yield return null;
        }

        private IEnumerator ArrowCountSpawner() {
            if (_statManager.FireLevel == 10 && ArrowCounter != 2)
                _arrowCounter++;
            if (_statManager.FireLevel == 20 && ArrowCounter != 3)
                _arrowCounter++;
            yield return null;
        }

        private IEnumerator SpawnWawes(float startDelay) {
            EndWave = false;
            yield return new WaitForSeconds(startDelay);
            for (int i = 0; i < EnemiesCount; i++) {
                Vector2 spawnPosition = new Vector2(16.25f, Random.Range(-2.6f, 4.5f));
                Quaternion spawnRotation = Quaternion.identity;
                CachedObjectPooler.SpawnObject((int)Tags.Enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(_spawnWait);
            }
        }

        private IEnumerator CheckWave() {
            var activeEnemiesList =
                GameObject.FindGameObjectsWithTag("Enemy").ToList().FindAll(e => e.activeInHierarchy);
            if (activeEnemiesList.Count > 0) {
                EndWave = true;
                yield return null;
            } else {
                if (EndWave)
                    _nextWave = true;
            }
        }

        protected IEnumerator SpawnDefender() {
            if (_statManager.WaterLevel == 10 && _spawnDefender != 1) {
                CachedObjectPooler.SpawnObject((int)Tags.Defender, new Vector2(-12.1f, -3.1f), Quaternion.identity);
                _spawnDefender++;
            }

            if (_statManager.WaterLevel == 20 && _spawnDefender != 2) {
                CachedObjectPooler.SpawnObject((int)Tags.Defender, new Vector2(-12.1f, 4.7f), Quaternion.identity);
                _spawnDefender++;
            }

            yield return null;
        }

        private IEnumerator IncreaseHeal() {
            if (_statManager.EarthLevel == 10 && _statManager.HealthRegeneration != 1)
                _statManager.HealthRegeneration++;
            if (_statManager.EarthLevel == 20 && _statManager.HealthRegeneration != 2)
                _statManager.HealthRegeneration++;
            yield return null;
        }
    }
}