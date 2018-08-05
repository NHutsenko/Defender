using System.Collections;
using UnityEngine;

namespace Assets.Scripts.WizardDefender {
    public class WizardDefenderAnimator : CachedMonoBehaviour {

        private float _nextAttack;
        private float _attackRate;

        // Use this for initialization
        void Start() {
            _attackRate = 1;
        }

        // Update is called once per frame
        void Update() {
            if (Time.time > _nextAttack) {
                _nextAttack = Time.time + _attackRate;
                StartCoroutine(PlayAnimation());
            }
        }

        private IEnumerator PlayAnimation() {
            if (FindClosestEnemy() < 15) {
                CachedAnimator.Play("WizardAttack");
                yield return new WaitForSeconds(.5f);
                CachedAnimator.Play("WizardIddle");
            } else {
                CachedAnimator.Play("WizardIddle");
            }

            yield return null;
        }

        private float FindClosestEnemy() {
            var enemies = GameObject.FindGameObjectsWithTag("Skeleton");
            float minDistance = 0;
            if (enemies.Length > 0)
                minDistance = Vector2.Distance(transform.position, enemies[0].transform.position);

            for (int i = 1; i < enemies.Length; i++) {
                if (!(minDistance > Vector2.Distance(transform.position, enemies[i].transform.position))) continue;
                minDistance = Vector2.Distance(transform.position, enemies[i].transform.position);
            }

            return minDistance;
        }
    }
}
