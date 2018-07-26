using UnityEngine;

namespace Assets.Scripts
{
    public class CatchedMonoBehaviour : MonoBehaviour {
        private SpriteRenderer _thisSpriteRender;

        public SpriteRenderer CatchedSpriteRender {
            get {
                if (_thisSpriteRender == null)
                    _thisSpriteRender = GetComponent<SpriteRenderer>();
                return _thisSpriteRender;
            }
        }

        private GameController _thisGameController;

        public GameController CatchedGameController {
            get {
                GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
                if (gameControllerObject != null)
                    _thisGameController = gameControllerObject.GetComponent<GameController>();
                else
                    Logger.LogError("Game Controller doesen't exists");
                return _thisGameController;
            }
        }

        private Rigidbody2D _thisRb2D;

        public Rigidbody2D CatchedRigidBody2D {
            get {
                if (_thisRb2D == null)
                    _thisRb2D = GetComponent<Rigidbody2D>();
                return _thisRb2D;
            }
        }

        private ObjectPooler _thisObjectPooler;

        public ObjectPooler CatchedObjectPooler {
            get {
                if(_thisObjectPooler == null)
                    _thisObjectPooler = ObjectPooler.Instance;
                return _thisObjectPooler;
            }
        }

        private Animator _thisAnimator;

        public Animator CatchedAnimator {
            get {
                if (_thisAnimator == null)
                    _thisAnimator = GetComponent<Animator>();
                return _thisAnimator;
            }
        }

        private StatsController _thisStats;

        public StatsController CatchedStats {
            get {
                if (_thisStats == null)
                    _thisStats = GetComponent<StatsController>();
                return _thisStats;
            }
        }
    }
}
