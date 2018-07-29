using UnityEngine;

namespace Assets.Scripts.WizardDefender {
    public class WizardBallMover : CatchedMonoBehaviour, IPooledObject {

        private float _speed;
        private GameObject _closestEnemy;

        public void OnObjectSpawn() {
            _speed = 10;
            _closestEnemy = FindClosestEnemy(15);
        }


        private void Update() {
            if (_closestEnemy == null) return;
            transform.position = Vector2.MoveTowards(transform.position,
                _closestEnemy.transform.position, Time.deltaTime * _speed);
        }

        private GameObject FindClosestEnemy(float attackRange) {
            var enemies = GameObject.FindGameObjectsWithTag("Skeleton");
            float minDistance = Vector2.Distance(transform.position, enemies[0].transform.position);
            int closestEnemy = 0;

            for (int i = 1; i < enemies.Length; i++) {
                if (!(minDistance > Vector2.Distance(transform.position, enemies[i].transform.position))) continue;
                minDistance = Vector2.Distance(transform.position, enemies[i].transform.position);
                closestEnemy = i;
            }

            return (minDistance < attackRange) ? enemies[closestEnemy] : null;
        }
    }
}
