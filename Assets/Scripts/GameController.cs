using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class GameController : CatchedMonoBehaviour {


        private float _spawnWait;
        private int _enemiesCount;
        private bool _nextWave;
        private int _points;
        private int _spawnDefender;
        private int _arrowCounter;
        private bool _endWave;
        public int ArrowCounter {
            get {
                return _arrowCounter;
            }
        }

        #region stats
        private int _enemyAttack;
        private int _enemyArmor;
        private float _enemyAttackSpeed;

        private int _playerAttack;
        private int _towerArmor;
        private int _towerAttack;
        private float _playerAttackSpeed;
        public int EnemyAttack { get { return _enemyAttack; } }
        public int EnemyArmor { get { return _enemyArmor; } }

        public float EnemyAttackSpeed { get { return _enemyAttackSpeed; } }
        public int PlayerAttack {
            get { return _playerAttack; }
            set { _playerAttack = value; }
        }
        public int TowerAttack {
            get { return _towerAttack; }
            set { _towerAttack = value; }
        }
        public int TowerArmor {
            get { return _towerArmor; }
            set { _towerArmor = value; }
        }

        public float PlayerAttackSpeed {
            get { return _playerAttackSpeed; }
            set { _playerAttackSpeed = value; }
        }

        public int Points {
            get { return _points; }
            set { _points = value; }
        }
        #endregion

        #region element levels
        private int _fireLevel;
        private int _waterLevel;
        private int _earthLevel;
        private int _windLevel;
        public int FireLevel {
            get {
                return _fireLevel;
            }

            set {
                _fireLevel = value;
            }
        }

        public int WaterLevel {
            get {
                return _waterLevel;
            }

            set {
                _waterLevel = value;
            }
        }

        public int EarthLevel {
            get {
                return _earthLevel;
            }

            set {
                _earthLevel = value;
            }
        }

        public int WindLevel {
            get {
                return _windLevel;
            }

            set {
                _windLevel = value;
            }
        }
        #endregion

        void Start() {
            _playerAttackSpeed = 1f;
            _enemyAttackSpeed = 1f;
            _spawnWait = 1f;
            _enemiesCount = 5;
            StartCoroutine(SpawnWawes(0));
            _enemyAttack = 1;
            _enemyArmor = 0;
            _points = 5;
            _playerAttackSpeed = 1f;
            _playerAttack = 20;
            _arrowCounter = 1;
            _spawnDefender = 0;
        }

        void LateUpdate() {
            if (_nextWave) {
                _nextWave = false;
                _enemyAttack++;
                _enemyArmor++;
                _points += 2;
                StartCoroutine(SpawnWawes(5));
            }

            StartCoroutine(ArrowCountSpawner());

            StartCoroutine(CheckWave());

            StartCoroutine(SpawnDefender());
        }

        private IEnumerator ArrowCountSpawner() {
            if (FireLevel == 10 && ArrowCounter != 2)
                _arrowCounter++;
            if (_fireLevel == 20 && ArrowCounter != 3)
                _arrowCounter++;
            yield return null;
        }

        private IEnumerator SpawnWawes(float startDelay) {
            _endWave = false;
            yield return new WaitForSeconds(startDelay);
            for (int i = 0; i < _enemiesCount; i++) {
                Vector2 spawnPosition = new Vector2(13, Random.Range(-4.5f, 4.5f));
                Quaternion spawnRotation = Quaternion.identity;
                ObjectPooler.Instance.SpawnObject((int)Tags.Skeleton, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(_spawnWait);
            }
        }

        private IEnumerator CheckWave() {
            var activeEnemiesList =
                GameObject.FindGameObjectsWithTag("Skeleton").ToList().FindAll(e => e.activeInHierarchy);
            if (activeEnemiesList.Count > 0) {
                _endWave = true;
                yield return null;
            } else {
                if (_endWave)
                    _nextWave = true;
            }
        }

        protected IEnumerator SpawnDefender() {
            if (_waterLevel == 10 && _spawnDefender != 1) {
                ObjectPooler.Instance.SpawnObject((int)Tags.Defender, new Vector2(-11.63f, -3.81f), Quaternion.identity);
                _spawnDefender++;
            }

            if (_waterLevel == 20 && _spawnDefender != 2) {
                ObjectPooler.Instance.SpawnObject((int)Tags.Defender, new Vector2(-11.63f, 3.81f), Quaternion.identity);
                _spawnDefender++;
            }
            yield return null;
        }
    }
}
