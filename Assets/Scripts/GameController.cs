using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class GameController : CatchedMonoBehaviour {

        private float _spawnWait;
        private int _enemiesCount;
        private bool _nextWave;
        private int _points;
        private bool _spawnDefender;
        private bool _endWave;
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


        void Start() {
            _playerAttackSpeed = 1f;
            _enemyAttackSpeed = 1f;
            _spawnWait = 1f;
            _enemiesCount = 5;
            StartCoroutine(SpawnWawes(0));
            _enemyAttack = 1;
            _enemyArmor = 0;
            _points = 0;
            _playerAttackSpeed = 0.7f;
            _playerAttack = 30;
        }

        void LateUpdate() {
            if (_nextWave) {
                _nextWave = false;
                _enemyAttack++;
                _enemyArmor++;
                _points += 2;
                StartCoroutine(SpawnWawes(5));
            }

            StartCoroutine(CheckWave());
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
            var activeEnemiesList = GameObject.FindGameObjectsWithTag("Skeleton").ToList().FindAll(e => e.activeInHierarchy);
            if (activeEnemiesList.Count > 0) {
                _endWave = true;
                yield return null;
            } else {
                if (_endWave)
                    _nextWave = true;
            }
        }

        protected void SpawnDefender(Vector2 pos, Quaternion rot) {
            _spawnDefender = false;
            ObjectPooler.Instance.SpawnObject((int)Tags.Defender, pos, rot);
        }
    }
}
