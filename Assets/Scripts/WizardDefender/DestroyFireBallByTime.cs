using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireBallByTime : MonoBehaviour, IPooledObject {

    private float _LifeTime;

    public void OnObjectSpawn() {
        _LifeTime = Time.time + 5f;
    }

    void Update()
    {
        if (!(Time.time > _LifeTime)) return;
        gameObject.SetActive(false);
    }
}
