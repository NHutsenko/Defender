using System;
using System.Collections;
using UnityEngine;
using Assets.Scripts;

public class AIArrowSpawner : CachedMonoBehaviour {

    private float _nextAttack;
    private float _attackRate;
    private bool _hasActiveEnemies;
    private int _activeEnemies;

    void Start() {
        _attackRate = 1f;
    }

    void Update() {
        StartCoroutine(CheckEnemiesAtScene());

        if (Time.time > _nextAttack && _hasActiveEnemies) {
            _nextAttack = Time.time + _attackRate;
            CachedObjectPooler.SpawnObject((int)Tags.Arrow, transform.position, transform.rotation);
        }
    }

    private IEnumerator CheckEnemiesAtScene() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _activeEnemies = 0;
        for (int i = 0; i < enemies.Length; i++) {
            if (enemies[i].activeInHierarchy)
                _activeEnemies++;
        }

        if (_activeEnemies > 0)
            _hasActiveEnemies = true;
        else
            _hasActiveEnemies = false;
        yield return null;
    }
}
