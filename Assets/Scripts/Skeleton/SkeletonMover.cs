using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMover : CatchedMonoBehaviour, IPooledObject {

    float speed;
	
    public void OnObjectSpawn() {
        speed = 2;
    }

	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-9.5f, transform.position.y), Time.deltaTime * speed);
    }
}
