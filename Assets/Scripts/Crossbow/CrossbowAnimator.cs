using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Crossbow
{
    public class CrossbowAnimator : CachedMonoBehaviour {

        [SerializeField]
        private Sprite[] _sprites;

        private float _nextAttack, _attackRate;

        private void LateUpdate() {
            _attackRate = CachedStatsManager.CrossbowAttackSpeed;
            if (!Input.GetMouseButtonDown(0) || !(Time.time > _nextAttack))
                return;
            _nextAttack = Time.time + _attackRate;
            StartCoroutine(AttackAnimation());
        }

        private IEnumerator AttackAnimation() {
            CachedSpriteRender.sprite = _sprites[0];
            yield return new WaitForSeconds(.5f);
            CachedSpriteRender.sprite = _sprites[1];
            yield return null;
        }
    }
}
