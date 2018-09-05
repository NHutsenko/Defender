using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Skeleton {
    public class SkeletonAnimator : CachedMonoBehaviour, IPooledObject {
        private float _nextAttack;
        private float _attackRate;

        public void OnObjectSpawn() {
            _attackRate = CachedStatsManager.UnitAttackSpeed;
        }
        private void Update() {
            if (transform.position.x > -9.5f)
                CachedAnimator.Play("SkeletonWalk");
            else if (transform.position.x == -9.5f && Time.time > _nextAttack) {
                _nextAttack = Time.time + _attackRate;
                StartCoroutine(PlayAnimation("SkeletonAttack"));
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Arrow"))
                return;
            CachedAnimator.Play(CachedStats.CurrentHp > 0 ? "SkeletonHurt" : "SkeletonDie");
        }

        private IEnumerator PlayAnimation(string animationName) {
            CachedAnimator.Play(animationName);
            yield return new WaitForSeconds(_attackRate);
        }
    }
}
