namespace Assets.Scripts.Arrow
{
    public class ArrowMover : CachedMonoBehaviour, IPooledObject {
        private float _speed;
        public void OnObjectSpawn () {
            _speed = .2f;
            CachedRigidBody2D.AddForce(transform.up * _speed);
        }
    }
}
