using System.Collections;
using UnityEngine;

namespace Assets.Scripts.WizardDefender {
    public class WizardDefenderAttack : CachedMonoBehaviour {

        private float _nextAttack;
        private float _attackRate;
        private float _attackRange;

        private void Start() {
            _attackRate = 1;
            _attackRange = 15;
        }

        private void LateUpdate() {
            GameObject closestEnemy = FindClosestEnemy(_attackRange);
            if (closestEnemy == null)
                return;
            if (!(Time.time > _nextAttack) || !closestEnemy.activeInHierarchy)
                return;
            _nextAttack = Time.time + _attackRate;
            ObjectPooler.Instance.SpawnObject((int)Tags.FireBall, transform.position, Quaternion.identity);

        }

        private GameObject FindClosestEnemy(float attackRange) {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float minDistance = 0;
            if (enemies.Length > 0)
                minDistance = Vector2.Distance(transform.position, enemies[0].transform.position);
            int closestEnemy = 0;

            for (int i = 1; i < enemies.Length; i++) {
                if (!(minDistance > Vector2.Distance(transform.position, enemies[i].transform.position)))
                    continue;
                minDistance = Vector2.Distance(transform.position, enemies[i].transform.position);
                closestEnemy = i;

            }
            
            return (minDistance < attackRange && enemies.Length > 0) ? enemies[closestEnemy] : null;
        }
    }
}
