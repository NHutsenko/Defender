using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowAnimator : CatchedMonoBehaviour {

    [SerializeField]
    Sprite[] sprites;

    float nextAttack, attackRate;

    private void LateUpdate() {
        attackRate = CatchedGameController.PlayerAttackSpeed;
        if(Input.GetMouseButtonDown(0) && Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            StartCoroutine(AttackAnimation());
        }
    }

    IEnumerator AttackAnimation() {
        CatchedSpriteRender.sprite = sprites[0];
        yield return new WaitForSeconds(.5f);
        CatchedSpriteRender.sprite = sprites[1];
        yield return null;
    }
}
