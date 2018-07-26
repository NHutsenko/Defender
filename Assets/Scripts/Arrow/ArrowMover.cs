namespace Assets.Scripts.Arrow
{
    public class ArrowMover : CatchedMonoBehaviour, IPooledObject {
        private float _speed;
        public void OnObjectSpawn () {
            _speed = .2f;
            CatchedRigidBody2D.AddForce(transform.up * _speed);
        }
    }
}
