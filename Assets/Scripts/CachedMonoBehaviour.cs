using UnityEngine;

namespace Assets.Scripts
{
    public class CachedMonoBehaviour : MonoBehaviour {
        private SpriteRenderer _thisSpriteRender;

        public SpriteRenderer CachedSpriteRender {
            get {
                if (_thisSpriteRender == null)
                    _thisSpriteRender = GetComponent<SpriteRenderer>();
                return _thisSpriteRender;
            }
        }

        private GameController _thisGameController;

        public GameController CachedGameController {
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

        public Rigidbody2D CachedRigidBody2D {
            get {
                if (_thisRb2D == null)
                    _thisRb2D = GetComponent<Rigidbody2D>();
                return _thisRb2D;
            }
        }

        private ObjectPooler _thisObjectPooler;

        public ObjectPooler CachedObjectPooler {
            get {
                if(_thisObjectPooler == null)
                    _thisObjectPooler = ObjectPooler.Instance;
                return _thisObjectPooler;
            }
        }

        private Animator _thisAnimator;

        public Animator CachedAnimator {
            get {
                if (_thisAnimator == null)
                    _thisAnimator = GetComponent<Animator>();
                return _thisAnimator;
            }
        }

        private StatsController _thisStats;

        public StatsController CachedStats {
            get {
                if (_thisStats == null)
                    _thisStats = GetComponent<StatsController>();
                return _thisStats;
            }
        }

        private StatsManager _thisStatManager;

        public StatsManager CachedStatsManager
        {
            get
            {
                if (_thisStatManager == null)
                    _thisStatManager = GameObject.Find("StatManager").GetComponent<StatsManager>();
                return _thisStatManager;
            }
        }
    }
}
