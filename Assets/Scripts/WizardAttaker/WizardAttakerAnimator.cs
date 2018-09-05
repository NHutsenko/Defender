using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class WizardAttakerAnimator : CachedMonoBehaviour {

    private float _attackRate;
    private float _nextAttack;

    void Start() {
        _attackRate = 1;
    }


    void Update() {
        if (transform.position.x > 3)
            CachedAnimator.Play("EnemyWizardRun");
        if (Time.time > _nextAttack && transform.position.x == 3) {
            _nextAttack = Time.time + _attackRate;
            StartCoroutine(AttackAnimation());
        }

    }

    private IEnumerator AttackAnimation() {
        CachedAnimator.Play("EnemyWizardAttack");
        yield return new WaitForSeconds(.5f);
        CachedAnimator.Play("EnemyWizardIddle");
        yield return null;
    }
}
