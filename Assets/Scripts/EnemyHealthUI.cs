using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Logger = UnityEngine.Logger;

public class EnemyHealthUI : CachedMonoBehaviour {

    private float _lastVisibleMadeTime;
    private readonly float _visibleTime = 3f;

    private Transform _ui;

    [SerializeField]
    private GameObject _healthBarPrefab;

    private Image _healthSlider;

    void Start() {
        GameObject canvas = GameObject.Find("Canvas");
        _ui = Instantiate(_healthBarPrefab, canvas.transform).transform;
        _healthSlider = _ui.GetChild(0).GetComponent<Image>();
        CachedStats.OnHealthChanged += OnHealthChanged;
        _ui.gameObject.SetActive(false);
    }

    private void LateUpdate() {
        if (_ui != null) {
            _ui.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 50, 0);
        }

        if (!(Time.time - _visibleTime > _lastVisibleMadeTime))
            return;
        if (_ui != null) _ui.gameObject.SetActive(false);
    }

    private void OnHealthChanged(int maxHP, int currentHP) {
        if (_ui != null) {
            _ui.gameObject.SetActive(true);
            _lastVisibleMadeTime = Time.time;

            float healthPrecent = currentHP / (float)maxHP;
            _healthSlider.fillAmount = healthPrecent;
            if (currentHP <= 0)
                Destroy(_ui.gameObject);
        }
    }

}
