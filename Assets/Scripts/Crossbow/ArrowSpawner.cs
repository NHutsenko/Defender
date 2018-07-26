using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Crossbow
{
    public class ArrowSpawner : CatchedMonoBehaviour {
        private float _attackRate;
        private float _nextAttack;

        void Update() {
            _attackRate = CatchedGameController.PlayerAttackSpeed;
            if (!Input.GetMouseButtonDown(0) || !(Time.time > _nextAttack)) return;
            _nextAttack = Time.time + _attackRate;
            StartCoroutine(SpawnArrow());
        }

        IEnumerator SpawnArrow() {
            yield return new WaitForSeconds(.5f);
            CatchedObjectPooler.SpawnObject((int)Tags.Arrow, transform.position, transform.rotation);
            CatchedObjectPooler.SpawnObject((int)Tags.Arrow, transform.position, transform.rotation);
            yield return null;
        }
    }
}
