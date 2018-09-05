using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Logger = UnityEngine.Logger;

public class ArmySpawner : CachedMonoBehaviour {

    private bool _isSpawnSkeleton;
    private bool _isSpawnWizard;

    private float _nextSpawnSkeleton;
    private float _skeletonSpawnRate;


    private float _nextSpawnWizard;
    private float _wizardSpawnRate;

    [SerializeField]
    private Image _skeletonSpawnButton;
    private float _skeletonActiveRespTime;
    private bool _resetSkeletonAnimation;

    [SerializeField]
    private Image _wizardSpawnButton;
    private float _wizardActiveRespTime;
    private bool _resetWizardAnimation;

    void Start() {
        _isSpawnSkeleton = _isSpawnWizard = false;
        _skeletonSpawnRate = 1.5f;
        _wizardSpawnRate = 2.5f;
    }

    private void Update() {
        if (_resetSkeletonAnimation) {
            if (Time.deltaTime > _nextSpawnSkeleton)
                _resetSkeletonAnimation = false;
            _skeletonActiveRespTime += Time.deltaTime;
            var percent = _skeletonActiveRespTime / _skeletonSpawnRate;
            _skeletonSpawnButton.fillAmount = Mathf.Lerp(0, 1, percent);
        }

        if (_resetWizardAnimation) {
            if (Time.deltaTime > _nextSpawnWizard)
                _resetWizardAnimation = false;
            _wizardActiveRespTime += Time.deltaTime;
            var percent = _wizardActiveRespTime / _wizardSpawnRate;
            _wizardSpawnButton.fillAmount = Mathf.Lerp(0, 1, percent);
        }

    }

    void LateUpdate() {
        if (Input.GetMouseButton(0)) {
            if (_isSpawnSkeleton && Time.time > _nextSpawnSkeleton && !CachedGameController.EndWave) {
                _isSpawnSkeleton = false;
                _resetSkeletonAnimation = true;
                _skeletonActiveRespTime = 0;
                _nextSpawnSkeleton = Time.time + _skeletonSpawnRate;

                SpawnObj(Tags.Enemy);
            } else if (_isSpawnWizard && Time.time > _nextSpawnWizard && !CachedGameController.EndWave) {
                _isSpawnWizard = false;
                _nextSpawnWizard = Time.time + _wizardSpawnRate;
                _resetWizardAnimation = true;
                _wizardActiveRespTime = 0;
                SpawnObj(Tags.Attacker);
            }
        }
    }

    private void SpawnObj(Tags tag) {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.x = 17;
        CachedObjectPooler.SpawnObject((int)tag, pos, Quaternion.identity);
    }

   

    public void SpawnSkeleton() {
        if (Time.time > _nextSpawnSkeleton && CachedGameController.EnemiesCount > 0) {
            CachedGameController.EnemiesCount--;
            _isSpawnSkeleton = true;
        }
    }

    public void SpawnWizard() {
        if (Time.time > _nextSpawnWizard && CachedGameController.EnemiesCount > 0) {
            CachedGameController.EnemiesCount--;
            _isSpawnWizard = true;
        }
    }
}
