using UnityEngine;

namespace Assets.Scripts.Skeleton
{
    public class SkeletonMover : CachedMonoBehaviour, IPooledObject {

        float _speed;
	
        public void OnObjectSpawn() {
            _speed = 2;
        }

        void Update () {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-9.5f, transform.position.y), Time.deltaTime * _speed);
        }
    }
}
