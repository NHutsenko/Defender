using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Crossbow
{
    public class CrossbowAnimator : CatchedMonoBehaviour {

        [SerializeField]
        private Sprite[] _sprites;

        private float _nextAttack, _attackRate;

        private void LateUpdate() {
            _attackRate = CatchedGameController.PlayerAttackSpeed;
            if (!Input.GetMouseButtonDown(0) || !(Time.time > _nextAttack)) return;
            _nextAttack = Time.time + _attackRate;
            StartCoroutine(AttackAnimation());
        }

        private IEnumerator AttackAnimation() {
            CatchedSpriteRender.sprite = _sprites[0];
            yield return new WaitForSeconds(.5f);
            CatchedSpriteRender.sprite = _sprites[1];
            yield return null;
        }
    }
}
