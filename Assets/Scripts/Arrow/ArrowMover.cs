using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : CatchedMonoBehaviour, IPooledObject {

    float speed;
	public void OnObjectSpawn () {
        speed = .2f;
        CatchedRigidBody2D.AddForce(transform.up * speed);
	}
}
