using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimator : CatchedMonoBehaviour, IPooledObject {

    float nextAttack, attackRate;

    public void OnObjectSpawn() {
        attackRate = CatchedGameController.EnemyAttackSpeed;
    }
    private void Update() {
        if (transform.position.x > -9.5f)
            CatchedAnimator.Play("SkeletonWalk");
        else if (transform.position.x == -9.5f && Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            StartCoroutine(PlayAnimation("SkeletonAttack"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Arrow")) {
            if (CatchedStats.CurrentHP <= 0) {
                CatchedGameController.AlivedEnemies--;
                CatchedAnimator.Play("SkeletonDie");
            }
                
            else
                CatchedAnimator.Play("SkeletonHurt");
        }
    }

    private IEnumerator PlayAnimation(string animationName) {
        CatchedAnimator.Play(animationName);
        yield return new WaitForSeconds(CatchedGameController.EnemyAttackSpeed);
    }
}
