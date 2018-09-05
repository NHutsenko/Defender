using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIRotator : MonoBehaviour
{

    private void LateUpdate()
    {
        StartCoroutine(FindClosestEnemy());
    }

    private IEnumerator FindClosestEnemy()
    {
        List<GameObject> enemiesList = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        if (enemiesList.Count == 0)
            yield break;
        enemiesList = enemiesList.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();

        float targetX = enemiesList[0].transform.position.x - transform.position.x;
        float targetY = enemiesList[0].transform.position.y - transform.position.y;

        float angle = Mathf.Atan2(targetY, targetX) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        yield return null;
    }
}
