using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : CatchedMonoBehaviour {

    float attackRate, nextAttack;
    void Update() {
        attackRate = CatchedGameController.PlayerAttackSpeed;
        if (Input.GetMouseButtonDown(0) && Time.time > nextAttack) {
            nextAttack = Time.time + attackRate;
            StartCoroutine(SpawnArrow());
        }
    }

    IEnumerator SpawnArrow() {
        yield return new WaitForSeconds(.5f);
        CatchedObjectPooler.SpawnObject((int)Tags.Arrow, transform.position, transform.rotation);
        CatchedObjectPooler.SpawnObject((int)Tags.Arrow, transform.position, transform.rotation);
        yield return null;
    }
}
