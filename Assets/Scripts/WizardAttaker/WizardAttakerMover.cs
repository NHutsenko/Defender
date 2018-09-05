using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class WizardAttakerMover : CachedMonoBehaviour, IPooledObject {

    private float _speed;
    public void OnObjectSpawn() {
        _speed = 2f;
    }

    void Start()
    {
        _speed = 2f;
    }


    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(3, transform.position.y),
            Time.deltaTime * _speed);
    }
}
